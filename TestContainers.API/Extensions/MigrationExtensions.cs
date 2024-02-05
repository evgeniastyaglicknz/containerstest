using Microsoft.EntityFrameworkCore;
using TestContainers.DAL;

namespace TestContainers.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DbTestContext dbContext =
                scope.ServiceProvider.GetRequiredService<DbTestContext>();

            dbContext.Database.Migrate();
        }
    }
}
