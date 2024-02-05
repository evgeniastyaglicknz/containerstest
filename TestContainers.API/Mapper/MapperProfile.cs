using AutoMapper;
using TestContainers.API.ViewModels;
using TestContainers.DAL.Entities;
using TestContainers.Models;

namespace TestContainers.API.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            CreateMap<WeatherModel, Weather>().ReverseMap();
            CreateMap<WeatherViewModel, WeatherModel>().ReverseMap();
        }
    }
}
