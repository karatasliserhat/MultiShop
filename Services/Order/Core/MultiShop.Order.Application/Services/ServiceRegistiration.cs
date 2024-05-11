using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultiShop.Order.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(opts =>
            {
                opts.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly);
            });

            services.AddAutoMapper(typeof(ServiceRegistiration).Assembly);

        }
    }
}
