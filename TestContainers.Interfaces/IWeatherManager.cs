using TestContainers.Models;

namespace TestContainers.Interfaces
{
    public interface IWeatherManager
    {
        IEnumerable<WeatherModel> GetWeatherData();
    }
}
