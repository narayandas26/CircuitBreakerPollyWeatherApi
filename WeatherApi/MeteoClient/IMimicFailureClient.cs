namespace WeatherApi.MeteoClient
{
    public interface IMimicFailureClient
    {
        Task<string> GetWeatherAsync(bool MimicFailure = true);
    }
}
