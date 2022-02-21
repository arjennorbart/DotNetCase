namespace ApiDotNetCase.src.Data
{
    public interface IRepository
    {
        Task<WeatherForecast?> Get(int id);
        Task<IEnumerable<WeatherForecast>> GetAll();
        Task<WeatherForecast> Create(WeatherForecast weatherForecast);
        Task Update(WeatherForecast weatherForecast);
        Task Delete(int id);
    }
}
