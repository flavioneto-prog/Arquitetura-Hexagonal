using Domain.Ports;
using Infra.Cache.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Cache
{
    public static class ServicesInfraCacheExtensions
    {
        public static IServiceCollection AddCacheRedisService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Redis");
            services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);
            services.AddTransient<ICacheRepository, CacheRepository>();
            return services;
        }
    }
}
