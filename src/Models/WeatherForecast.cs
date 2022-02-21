using System.ComponentModel.DataAnnotations;

namespace ApiDotNetCase
{
    public class WeatherForecast
    {
        [Key] public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
        
        public WeatherForecast()
        {
        }

        public WeatherForecast(int id, DateTime? date, int temperatureC, string? summary)
        {
            Id = id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    }
}
