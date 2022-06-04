using LoginSample.Service.Abstractions;
using LoginSample.Service.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace LoginSample.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}