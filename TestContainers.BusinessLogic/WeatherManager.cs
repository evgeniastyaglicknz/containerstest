using TestContainers.DAL;
using TestContainers.Interfaces;
using TestContainers.Models;

namespace TestContainers.BusinessLogic
{
    public class WeatherManager : IWeatherManager
    {
        private readonly DbTestContext _db;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherManager(DbTestContext db) 
        { 
            _db = db;
        }

        public IEnumerable<WeatherModel> GetWeatherData()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
