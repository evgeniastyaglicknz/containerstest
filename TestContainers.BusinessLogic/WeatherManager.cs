using TestContainers.DAL;
using TestContainers.Interfaces;
using TestContainers.Models;
using TestContainers.Models.StaticData;

namespace TestContainers.BusinessLogic
{
    public class WeatherManager : IWeatherManager
    {
        private readonly DbTestContext _db;

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
                Summary = StaticData.Summaries[Random.Shared.Next(StaticData.Summaries.Length)]
            })
            .ToArray();
        }
    }
}
