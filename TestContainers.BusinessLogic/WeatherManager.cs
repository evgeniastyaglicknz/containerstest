using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestContainers.DAL;
using TestContainers.DAL.Entities;
using TestContainers.Interfaces;
using TestContainers.Models;
using TestContainers.Models.StaticData;

namespace TestContainers.BusinessLogic
{
    public class WeatherManager : IWeatherManager
    {
        private readonly DbTestContext _db;
        private readonly IMapper _mapper;

        public WeatherManager(DbTestContext db, IMapper mapper) 
        { 
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<WeatherModel>> GetWeatherData()
        {
            var data = await _db.WeatherData.ToListAsync();

            return _mapper.Map<List<Weather>, List<WeatherModel>>(data);

        }
    }
}
