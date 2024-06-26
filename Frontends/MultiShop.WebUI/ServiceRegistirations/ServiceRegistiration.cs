﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using MultiShop.Shared.Handlers;
using MultiShop.Shared.Services.Abstract;
using MultiShop.Shared.Services.Service;
using MultiShop.Shared.Settings;
using MultiShop.WebUI.LocalizationServices;
using MultiShop.WebUI.Resources;
using System.Globalization;
using System.Reflection;

namespace MultiShop.WebUI.ServiceRegistirations
{
    public static class ServiceRegistiration
    {
        public static void AddServiceRegistiration(this IServiceCollection Services, IConfiguration Configuration)
        {
            //Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
            //{
            //    opt.LoginPath = new PathString("/Login/Index");
            //    opt.LogoutPath = new PathString("/Login/Logout");
            //    opt.AccessDeniedPath = new PathString("/Pages/AccessDenied");
            //    opt.Cookie.HttpOnly = true;

            //    opt.Cookie.SameSite = SameSiteMode.Strict;
            //    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            //    opt.Cookie.Name = "MultiShopJwt";
            //});

            

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
            Services.AddScoped<IGetUserService, GetUserService>();
            Services.AddScoped<IAuthorizationTokenApiService, AuthorizationTokenApiService>();


            Services.AddSignalR();

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




            //Localization işlemi

            Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });



            Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
               AddDataAnnotationsLocalization(opt =>
               {

                   opt.DataAnnotationLocalizerProvider = (type, factory) =>
                   {
                       var assembly = new AssemblyName(typeof(AppResource).GetTypeInfo().Assembly.FullName);
                       return factory.Create("AppResource", assembly.Name);
                   };
               });


            Services.Configure<RequestLocalizationOptions>(opt =>
            {
                var caltures = new List<CultureInfo> {
                        new CultureInfo("tr-TR"),
                        new CultureInfo("en-US"),
                        new CultureInfo("fr-FR"),
                        new CultureInfo("it-IT"),
                        new CultureInfo("de-DE")
                };

                opt.DefaultRequestCulture = new RequestCulture(new CultureInfo("tr-TR"));
                opt.SupportedCultures = caltures;
                opt.SupportedUICultures = caltures;

                opt.RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            Services.AddScoped<LocalizationService>();
            //Localization işlemi end








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
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
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

            //Message Api

            Services.AddHttpClient<IMessageReadApiService, MessageReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.MessageApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<IMessageCommandApiService, MessageCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.MessageApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            //Message Api End

            //Cargo Api start

            Services.AddHttpClient<ICargoCompanyReadApiService, CargoCompanyReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CargoApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<ICargoCompanyCommandApiService, CargoCompanyCommandApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CargoApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            Services.AddHttpClient<ICargoCustomerReadApiService, CargoCustomerReadApiService>(opt =>
            {
                opt.BaseAddress = new Uri(apiData.CargoApiUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            //Cargo Api end
        }
    }
}
