using Microsoft.EntityFrameworkCore;
using TestContainers.DAL.Entities;

namespace TestContainers.DAL
{
    public class DbTestContext: DbContext
    {
        private readonly string _defaultConnectionString;

        public DbTestContext(DbContextOptions<DbTestContext> options): base(options) 
        {
            _defaultConnectionString = "Host=localhost;Port=5432;Database=test1;Username=postgres;Password=!1q2w3e4r;";
            //_defaultConnectionString = "postgresql://localhost/test1?user=postgres&password=!1q2w3e4r";
            //_defaultConnectionString = "Server=localhost;Port=5432;Database=test1;User Id=postgres;Password=!1q2w3e4r;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If DbContextOptions does not have a connection string configured, use the default connection string
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_defaultConnectionString);
            }
        }
        public DbSet<Weather> WeatherData { get; set; }
    }
}
