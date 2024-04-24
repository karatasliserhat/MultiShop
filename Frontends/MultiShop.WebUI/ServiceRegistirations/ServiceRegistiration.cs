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
                return sp.GetRequiredService<IOptions<ApiSettings>>().Value;
            });
            var scope = Services.BuildServiceProvider();

            var apiData = scope.GetRequiredService<IOptions<ApiSettings>>().Value;

            Services.AddScoped(typeof(IApiReadService<>), typeof(ApiReadService<>));


            //Catalog Api
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

            Services.AddHttpClient<IBrandReadApiService, BrandReadService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IBrandCommandApiService, BrandCommandService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IAboutReadApiService, AboutReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IAboutCommandApiService, AboutCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IProductImageReadApiService, ProductImageReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IProductImageCommandApiService, ProductImageCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IProductDetailReadApiService, ProductDetailReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IProductDetailCommandApiService, ProductDetailCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IContactReadApiService, ContactReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            Services.AddHttpClient<IContactCommandApiService, ContactCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            });
            //Catalog api End
            //Comment Api
            Services.AddHttpClient<ICommentReadApiService, CommentReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CommentApiUrl.ToString());
            });
            Services.AddHttpClient<ICommentCommandApiService, CommentCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CommentApiUrl.ToString());
            });
            //Comment Api End

            //Identity Api
            Services.AddHttpClient<IIdentityReadApiService, IdentityReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.IdentityApiUrl.ToString());
            });
            Services.AddHttpClient<IIdentityCommandApiService, IdentityCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.IdentityApiUrl.ToString());
            });
            //Identity Api End
        }
    }
}
