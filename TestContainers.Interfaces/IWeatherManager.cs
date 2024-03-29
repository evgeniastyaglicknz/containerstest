﻿using TestContainers.Models;

namespace TestContainers.Interfaces
{
    public interface IWeatherManager
    {
        Task<List<WeatherModel>> GetWeatherData();
    }
}
