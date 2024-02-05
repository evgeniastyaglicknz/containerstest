using Microsoft.EntityFrameworkCore;
using TestContainers.DAL;
using TestContainers.DAL.Entities;
using TestContainers.Models.StaticData;

namespace TestContainers.API.Extensions
{
    public static class DataSeedExtensions
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DbTestContext dbContext =
                scope.ServiceProvider.GetRequiredService<DbTestContext>();

            if (dbContext.WeatherData.Any())
            {
                return;
            }

            var data = Enumerable.Range(1, 5).Select(index => new Weather
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = StaticData.Summaries[Random.Shared.Next(StaticData.Summaries.Length)]
            }).ToArray();

            dbContext.WeatherData.AddRangeAsync(data);

            dbContext.SaveChanges();
        }
    }
}
