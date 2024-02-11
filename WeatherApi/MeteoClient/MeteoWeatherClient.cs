
namespace WeatherApi.MeteoClient
{
    public class MeteoWeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;

        public MeteoWeatherClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("MeteoClient");
        }

        public async Task<string> GetWeatherAsync()
        {
            var weatherdetails = await _httpClient.GetStringAsync("forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m");
            return weatherdetails;
        }
    }
}
