using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concreate;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using System.Reflection;

namespace MultiShop.Cargo.BusinessLayer.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddServiceBusinessLayer(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            Services.AddScoped<ICargoDetailService, CargoDetailManager>();
            Services.AddScoped<ICargoOperationService, CargoOperationManager>();
            Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

        }
    }
}
