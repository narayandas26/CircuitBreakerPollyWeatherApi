namespace WeatherApi.MeteoClient
{
    public interface IWeatherClient
    {
        Task<string> GetWeatherAsync();
    }
}
