namespace ApiDotNetCase
{
    public class WeatherForecast
    {
        private static int _count = 0;
        private readonly string[] _summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public WeatherForecast()
        {
            _count++;
        }

        public WeatherForecast GetPrediction()
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(_count),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            };
        }
    }
}
