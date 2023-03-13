namespace ambient_weather_backend.Services
{
    using ambient_weather_backend.Models;

    using Newtonsoft.Json;

    public class ApiCredentialService : IApiCredentialService
    {
        private readonly ILogger<ApiCredentialService> logger;

        public ApiCredentialService(ILogger<ApiCredentialService> logger)
        { 
            this.logger = logger;
        }

        // Fetches API credentials
        // If 'ASPNETCORE_ENVIRONMENT' is...
        //      set to 'Prod', it will fetch from environment variables
        //      set to 'Dev', it will fetch from file (Constants.DevApiKeysFile)
        public AmbientWeatherConfig GetApiCredentials()
        {
            var aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();

            logger.LogInformation($"ASPNETCORE_ENVIRONMENT = '{aspNetCoreEnvironment}'");

            if (aspNetCoreEnvironment == "development")
            {
                return GetApiCredentialsFromFile();
            }
            else if (aspNetCoreEnvironment == "production")
            {
                return GetApiCredentialsFromEnvironmentVariables();
            }
            else
            {
                throw new Exception("ASPNETCORE_ENVIRONMENT variable not set to 'development' or 'production'");
            }
        }

        // Used in production environments to get API credentials (Ambient Weather applicationKey & apiKey) from environment variables
        private AmbientWeatherConfig GetApiCredentialsFromEnvironmentVariables()
        {
            logger.LogInformation("Fetching api credentials from environment variables...");

            var applicationKey = Environment.GetEnvironmentVariable("application_key");
            var apiKey = Environment.GetEnvironmentVariable("api_key");
            var macAddress = Environment.GetEnvironmentVariable("mac_address");

            return new AmbientWeatherConfig
            {
                ApplicationKey = applicationKey,
                ApiKey = apiKey,
                MacAddress = macAddress
            };
        }

        // Used in dev environments to get API credentials from json file
        private AmbientWeatherConfig GetApiCredentialsFromFile()
        {
            logger.LogInformation($"Fetching api credentials from file {Constants.DevApiCredentialsFile}...");

            var fileContents = File.ReadAllText(Constants.DevApiCredentialsFile);
            var ambientWeatherConf = JsonConvert.DeserializeObject<AmbientWeatherConfig>(fileContents);

            return ambientWeatherConf;
        }
    }
}
