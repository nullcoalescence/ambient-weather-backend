using Newtonsoft.Json;

namespace ambient_weather_backend.Models
{
    public class AmbientWeatherConfig
    {
        [JsonProperty("application_key")]
        public string? ApplicationKey { get; set; }

        [JsonProperty("api_key")]
        public string? ApiKey { get; set; }

        [JsonProperty("mac_address")]
        public string? MacAddress { get; set; }
    }
}
