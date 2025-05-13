using Domain.Ports;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
    public static class ServiceInfraDataExtensions
    {
        public static IServiceCollection AddDataBaseInMemoryService(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("test"));
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddPostgreSqlService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(connectionString, options => options.MigrationsAssembly("Users.Api")));
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}