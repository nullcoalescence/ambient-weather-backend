namespace ambient_weather_backend.Services
{
    using ambient_weather_backend.Models;

    public interface IApiCredentialService
    {
        AmbientWeatherConfig GetApiCredentials();
    }
}
