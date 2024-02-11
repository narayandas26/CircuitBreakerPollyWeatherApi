using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.MeteoClient;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalWeatherController : ControllerBase
    {
        IMimicFailureClient _weatherClient;

        public LocalWeatherController(IMimicFailureClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpGet(Name = "GetLocalWeather")]
        public async Task<string> Get(bool mimicfailure = false)
        {
            return await _weatherClient.GetWeatherAsync(mimicfailure);
        }
    }
}
