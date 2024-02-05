namespace TestContainers.API.ViewModels
{
    public class WeatherViewModel
    {
        public int ID { get; set; }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
