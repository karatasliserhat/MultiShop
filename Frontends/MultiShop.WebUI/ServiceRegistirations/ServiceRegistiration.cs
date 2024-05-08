using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Shared.Handlers;
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
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = new PathString("/Login/Index");
                opt.LogoutPath = new PathString("/Login/Logout");
                opt.AccessDeniedPath = new PathString("/Pages/AccessDenied");
                opt.Cookie.HttpOnly = true;

                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "MultiShopJwt";
            });

            Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
            {

                opts.LoginPath = new PathString("/Login/SignIn");
                opts.ExpireTimeSpan = TimeSpan.FromDays(5);
                opts.Cookie.Name = "MultiShopCookie";
                opts.SlidingExpiration = true;

            });
            Services.AddHttpClient();
            Services.AddAccessTokenManagement();
            Services.AddHttpContextAccessor();
            Services.AddScoped<ILoginService, LoginService>();
            Services.AddScoped<IAuthorizationTokenApiService, AuthorizationTokenApiService>();

            Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            Services.Configure<ApiSettings>(Configuration.GetSection(nameof(ApiSettings)));
            Services.Configure<ClientSettings>(Configuration.GetSection(nameof(ClientSettings)));

            Services.AddScoped<IApiSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<ApiSettings>>().Value;
            });

            Services.AddScoped<IClientSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<ClientSettings>>().Value;
            });

            Services.AddScoped<IIdentitySignInService, IdentitySignInService>();

            Services.AddScoped<IClientCredentialAccessTokenService, ClientCredentialAccessTokenService>();

            Services.AddScoped<ResourceOwnerPasswordTokenHandler>();

            Services.AddScoped<ClientCredentialTokenHandler>();

            var scope = Services.BuildServiceProvider();


            var apiData = scope.GetRequiredService<IOptions<ApiSettings>>().Value;


            Services.AddScoped(typeof(IApiReadService<>), typeof(ApiReadService<>));

            //Catalog Api
            Services.AddHttpClient<ICategoryReadApiService, CategoryReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<ICategoryCommandApiService, CategoryCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IProductReadApiService, ProductReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IProductCommandApiService, ProductCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IFeatureSliderReadApiService, FeatureSliderReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IFeatureSliderCommandApiService, FeatureSliderCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<ISpecialOfferReadApiService, SpecialOfferReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<ISpecialOfferCommandApiService, SpecialOfferCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IFeatureReadApiService, FeatureReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IFeatureCommandApiService, FeatureCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IOfferDiscountReadApiService, OfferDiscountReadApiService>(opt =>
           {
               opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
           }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IOfferDiscountCommandApiService, OfferDiscountCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IBrandReadApiService, BrandReadService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IBrandCommandApiService, BrandCommandService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IAboutReadApiService, AboutReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IAboutCommandApiService, AboutCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IProductImageReadApiService, ProductImageReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IProductImageCommandApiService, ProductImageCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IProductDetailReadApiService, ProductDetailReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IProductDetailCommandApiService, ProductDetailCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IContactReadApiService, ContactReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<IContactCommandApiService, ContactCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CatalogApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
            //Catalog api End
            //Comment Api
            Services.AddHttpClient<ICommentReadApiService, CommentReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CommentApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            Services.AddHttpClient<ICommentCommandApiService, CommentCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CommentApiUrl.ToString());
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
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
            Services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.IdentityApiUrl.ToString());
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            //Identity Api End

            //Basket Api Start
            Services.AddHttpClient<IBasketReadApiService, BasketReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.BasketApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<IBasketCommandApiService, BasketCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.BasketApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            //Basket Api End

            //Discount Api Start
            Services.AddHttpClient<IDiscountReadApiService, DiscountReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.DiscountApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<IDiscountCommandApiService, DiscountCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.DiscountApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            //Discount Api End

            //Order Api Start
            Services.AddHttpClient<IOrderAddressReadApiService, IOrderAddressReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.OrderApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<IOrderAddressCommandApiService, OrderAddressCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.OrderApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


            Services.AddHttpClient<IOrderDetailReadApiService, OrderDetailReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.OrderApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<IOrderDetailCommandApiService, OrderDetailCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.OrderApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


            Services.AddHttpClient<IOrderingReadApiService, OrderingReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.OrderApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<IOrderingCommandApiService, OrderingCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.OrderApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            //Order Api End
        }
    }
}
