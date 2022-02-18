using ApiDotNetCase.src.Application;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNetCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private WeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _service.GetWeatherForecast();
        }
    }
}
