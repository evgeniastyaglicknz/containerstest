using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestContainers.API.ViewModels;
using TestContainers.Interfaces;
using TestContainers.Models;

namespace TestContainers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IWeatherManager _weatherManager;
    private IMapper _mapper;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherManager manager, IMapper mapper)
    {
        _logger = logger;
        _weatherManager = manager;  
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherViewModel>> Get()
    {
        var data = await _weatherManager.GetWeatherData();
        return _mapper.Map<IEnumerable<WeatherModel>, IEnumerable<WeatherViewModel>>(data);
    }
}
