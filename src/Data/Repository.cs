using ApiDotNetCase.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNetCase.src.Data
{
    public class Repository : IRepository
    {
        private readonly WeatherForecastContext _context;

        public Repository(WeatherForecastContext context)
        {
            _context = context;
        }

        public async Task<WeatherForecast?> Get(int id)
        {
            return await _context.WeatherForecasts.FindAsync(id);
        }
        public async Task<IEnumerable<WeatherForecast>> GetAll()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }

        public async Task<WeatherForecast> Create(WeatherForecast weatherForecast)
        {
            _context.WeatherForecasts.Add(weatherForecast);
            await _context.SaveChangesAsync();

            return weatherForecast;
        }

        public async Task Update(WeatherForecast weatherForecast)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(weatherForecast).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var weatherForecast = await _context.WeatherForecasts.FindAsync(id);
            if (weatherForecast != null) _context.WeatherForecasts.Remove(weatherForecast);

            await _context.SaveChangesAsync();
        }

    }
}
