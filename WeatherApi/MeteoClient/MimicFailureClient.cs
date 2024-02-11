using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;

namespace WeatherApi.MeteoClient
{
    public class MimicFailureClient : IMimicFailureClient
    {
        private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy = Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()            
            .OrTransientHttpError()
            .OrTransientHttpStatusCode()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));

        private readonly HttpClient _httpClient;

        public MimicFailureClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("MimicFailureClient");
        }

        public async Task<string> GetWeatherAsync(bool MimicFailure = true)
        {
            string mimic = MimicFailure ? "1" : "0";
            var response = await _circuitBreakerPolicy.ExecuteAsync(() => 
                _httpClient.GetAsync($"weather?mimicfailure={mimic}")                    
            );
            return await response.Content.ReadAsStringAsync();
        }
    }
}
