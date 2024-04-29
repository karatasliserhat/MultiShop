using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial:ViewComponent
    {
        private readonly IProductReadApiService _productReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _FeatureProductsDefaultComponentPartial(IProductReadApiService productReadApiService, IDataProtectionProvider dataProtection, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _productReadApiService = productReadApiService;
            _dataProtector = dataProtection.CreateProtector("FeatureProductDefaultViewComponent");
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _productReadApiService.GetListAsync("Products", token.AccessToken);
            result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.ProductId));
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
