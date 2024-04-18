using Microsoft.Extensions.Options;
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

            Services.AddHttpClient<IProductReadApiService, ProductReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IProductCommandApiService, ProductCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IFeatureSliderReadApiService, FeatureSliderReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IFeatureSliderCommandApiService, FeatureSliderCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<ISpecialOfferReadApiService, SpecialOfferReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<ISpecialOfferCommandApiService, SpecialOfferCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IFeatureReadApiService, FeatureReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IFeatureCommandApiService, FeatureCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
             Services.AddHttpClient<IOfferDiscountReadApiService, OfferDiscountReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IOfferDiscountCommandApiService, OfferDiscountCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });

        }
    }
}
