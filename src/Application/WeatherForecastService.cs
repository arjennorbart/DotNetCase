using ApiDotNetCase.src.Data;

namespace ApiDotNetCase.src.Application
{
    public class WeatherForecastService
    {
        private IRepository _repository;
        public WeatherForecastService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<WeatherForecast?> GetWeatherForecast(int id)
        {
            var weatherForecast = await _repository.Get(id);
            if (weatherForecast == null)
                return null;
            return weatherForecast;
        }

        public Task<IEnumerable<WeatherForecast>> GetPrediction()
        {
            return _repository.GetAll();
        }

        public async Task<WeatherForecast> CreateNewRandomForecast()
        {
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            var weatherForecast = await _repository.Create( new WeatherForecast
            {
                Id = new Random().Next(),
                Date = DateTime.Now.AddDays(new Random().Next(1, 11)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });

            return weatherForecast;
        }

        public async Task<WeatherForecast?> UpdateForecast(WeatherForecast weatherForecast)
        {
            if (await _repository.Get(weatherForecast.Id) == null)
                return null;

            await _repository.Update(weatherForecast);
            return weatherForecast;
        }

        public async Task<WeatherForecast?> DeleteForecast(int id)
        {
            if (await _repository.Get(id) == null)
                return null;
            var weatherForecast = await _repository.Get(id);

            await _repository.Delete(id);

            return weatherForecast;
        }
    }
}
