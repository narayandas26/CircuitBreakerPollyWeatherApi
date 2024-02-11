namespace MinimalWeatherApi.MeteoClient
{
    public interface IWeatherClient
    {
        Task<string> GetWeatherAsync();
    }
}
