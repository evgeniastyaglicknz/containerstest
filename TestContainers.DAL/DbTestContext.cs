using Microsoft.EntityFrameworkCore;
using TestContainers.DAL.Entities;

namespace TestContainers.DAL
{
    public class DbTestContext: DbContext
    {
        public DbTestContext(DbContextOptions<DbTestContext> options): base(options) { }

        public DbSet<Weather> WeatherData { get; set; }
    }
}
