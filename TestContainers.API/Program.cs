
using Microsoft.EntityFrameworkCore;
using TestContainers.API.Extensions;
using TestContainers.API.Mapper;
using TestContainers.BusinessLogic;
using TestContainers.DAL;
using TestContainers.Interfaces;

namespace TestContainers.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(MapperProfile));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DbTestContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("testPortgres"), b => b.MigrationsAssembly("TestContainers.API")));

        builder.Services.AddTransient<IWeatherManager, WeatherManager>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.ApplyMigrations();
        app.SeedDatabase();

        app.MapControllers();

        app.Run();
    }
}
