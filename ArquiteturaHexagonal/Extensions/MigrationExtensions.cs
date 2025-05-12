using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ArquiteturaHexagonal.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder applicationBuilder)
        {
            try
            {
                using IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope();

                using PostgreSqlContext postgreSqlContext = scope.ServiceProvider.GetRequiredService<PostgreSqlContext>();

                postgreSqlContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
