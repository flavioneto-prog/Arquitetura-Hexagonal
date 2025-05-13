using Application.Services;
using Domain.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServicesApplicationExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserServiceManager>();
            services.AddTransient<ICacheService, CacheServiceManager>();
            return services;
        }
    }
}
