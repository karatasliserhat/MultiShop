using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IBrandReadApiService _brandReadApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _VendorDefaultComponentPartial(IBrandReadApiService brandReadApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _brandReadApiService = brandReadApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _brandReadApiService.GetListAsync("Brands", token.AccessToken);
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
