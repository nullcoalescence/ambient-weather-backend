namespace ambient_weather_backend.Controllers
{
    using ambient_weather_backend.Models;
    using ambient_weather_backend.Services;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    [ApiController]
    [Route("[controller]")]
    public class AmbientWeatherController : ControllerBase
    {
        private readonly IAmbientWeatherConfigService apiCredentialService;

        private readonly HttpClient httpClient;
        private readonly ILogger<AmbientWeatherController> logger;

        private readonly AmbientWeatherConfig ambientWeatherConf;

        public AmbientWeatherController(IAmbientWeatherConfigService apiCredentialService, HttpClient httpClient, ILogger<AmbientWeatherController> logger)
        {
            ArgumentNullException.ThrowIfNull(nameof(apiCredentialService));
            ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));

            this.apiCredentialService = apiCredentialService;
            this.logger = logger;
            this.httpClient = httpClient;

            this.httpClient.BaseAddress = new Uri(Constants.AmbientWeatherApiBaseUrl);

            this.ambientWeatherConf = apiCredentialService.GetApiCredentials(); 
        }
        
        /*
         *  Makes a call to Ambient Weather's '/devices' endpoint.
         */
        [HttpGet("ListDevicesAndMostRecentData")]
        public async Task<IActionResult> ListDevicesAndMostRecentData()
        {
            var endpointUrl = BuildListDevicesAndMostRecentDataEndpointUrl();
            logger.LogInformation($"Making GET request to endpoint {endpointUrl}");

            using HttpResponseMessage response = await this.httpClient.GetAsync(endpointUrl);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            logger.LogDebug(jsonResponse);

            var model = JsonConvert.DeserializeObject<List<ListDevicesAndMostRecentDataResponse>>(jsonResponse);
            return Ok(model?.FirstOrDefault());
        }

        [HttpGet("QueryDeviceData")]
        public async Task<IActionResult> QueryDeviceData([FromQuery] int limit)
        {
            var endpointUrl = BuildQueryDeviceDataEndpointUrl(limit);
            logger.LogInformation($"Making GET request to endpoint {endpointUrl}");

            using HttpResponseMessage response = await this.httpClient.GetAsync(endpointUrl);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            logger.LogDebug(jsonResponse);

            var model = JsonConvert.DeserializeObject<List<QueryDeviceDataResponse>>(jsonResponse);
            return Ok(model);
        }

        /*
         *  Ambient Weather API endpoint URL endpoint builders
         */
        private string BuildListDevicesAndMostRecentDataEndpointUrl()
        {
            var url = $"devices?applicationKey={this.ambientWeatherConf.ApplicationKey}&apiKey={this.ambientWeatherConf.ApiKey}";
            return url;
        }

        private string BuildQueryDeviceDataEndpointUrl(int limit)
        {
            var url = $"devices/{this.ambientWeatherConf.MacAddress}?applicationKey={this.ambientWeatherConf.ApplicationKey}&apiKey={this.ambientWeatherConf.ApiKey}&limit={limit}";
            return url;
        }
    }
}
