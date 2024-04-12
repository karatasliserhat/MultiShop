﻿using Microsoft.Extensions.Options;
using MultiShop.Shared.Services.Abstract;
using MultiShop.Shared.Services.Service;
using MultiShop.Shared.Settings;
using System.Reflection;

namespace MultiShop.WebUI.ServiceRegistirations
{
    public static class ServiceRegistiration
    {
        public static void AddServiceRegistiration(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            Services.Configure<ApiSettings>(Configuration.GetSection(nameof(ApiSettings)));

            Services.AddScoped<IApiSettings>(sp =>
            {
                var data = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
                return data;
            });
            var scope = Services.BuildServiceProvider();

            var apiData = scope.GetRequiredService<IOptions<ApiSettings>>().Value;

            Services.AddScoped(typeof(IApiReadService<>), typeof(ApiReadService<>));

            Services.AddHttpClient<ICategoryReadApiService, CategoryReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<ICategoryCommandApiService, CategoryCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
        }
    }
}
