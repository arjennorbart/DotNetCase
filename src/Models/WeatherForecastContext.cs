using Microsoft.EntityFrameworkCore;

namespace ApiDotNetCase.src.Models
{
    public class WeatherForecastContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
