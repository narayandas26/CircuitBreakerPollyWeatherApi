namespace MinimalWeatherApi.MeteoClient
{
    public class MimicFailureClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;

        public MimicFailureClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("MimicFailureClient");
        }

        public async Task<string> GetWeatherAsync()
        {
            string mimic = "1";
            var weatherdetails = await _httpClient.GetStringAsync($"weather?mimicfailure={mimic}");
            return weatherdetails;
        }
    }
}
