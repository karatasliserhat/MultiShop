using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutFeatureViewComponents
{
    public class _AboutFooterComponentPartial : ViewComponent
    {
        private readonly IAboutReadApiService _aboutReadApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _AboutFooterComponentPartial(IAboutReadApiService aboutReadApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _aboutReadApiService = aboutReadApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _aboutReadApiService.GetListAsync("Abouts", token.AccessToken);
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
