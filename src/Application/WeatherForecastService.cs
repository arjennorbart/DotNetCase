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

        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            var predictions = new List<WeatherForecast>();
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast()).ToList();
            foreach (var prediction in forecast)
                predictions.Add(prediction.GetPrediction());
            return predictions;
        }
    }
}
