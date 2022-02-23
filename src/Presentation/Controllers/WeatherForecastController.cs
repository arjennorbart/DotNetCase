using ApiDotNetCase.src.Application;
using Microsoft.AspNetCore.Mvc;
using ApiDotNetCase.src.Presentation.Controllers.Dto;

using Microsoft.AspNetCore.Authorization;

namespace ApiDotNetCase.Controllers
{
    [Authorize]
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

        [HttpGet(Name = "GetPrediction")]
        public Task<IEnumerable<WeatherForecast>> GetAll()
        {
            return _service.GetPrediction();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetWeatherForecastById(int id)
        {
            var forecast = await _service.GetWeatherForecast(id);
            if (forecast == null)
                return NotFound();

            return Ok(forecast);
        }

        [HttpPost]
        public async Task<ActionResult> CreateForecast()
        {
            var forecast = await _service.CreateNewRandomForecast();
            return Ok(forecast);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateForecast(int id, [FromBody] WeatherForecastDto dto)
        {
            if (GetWeatherForecastById(id) == null)
                return NotFound();

            var forecast = await _service.UpdateForecast(new WeatherForecast(id, dto.Date, dto.TemperatureC, dto.Summary));

            return Ok(forecast);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteForecast(int id)
        {
            if (GetWeatherForecastById(id) == null)
                return NotFound();

            var forecast = await _service.DeleteForecast(id);

            return Ok(forecast);
        }
    }
}
