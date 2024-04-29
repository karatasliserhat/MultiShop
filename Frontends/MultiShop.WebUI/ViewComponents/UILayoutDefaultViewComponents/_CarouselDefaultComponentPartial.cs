using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderReadApiService _featureSliderReadApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _CarouselDefaultComponentPartial(IFeatureSliderReadApiService featureSliderReadApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _featureSliderReadApiService = featureSliderReadApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _featureSliderReadApiService.GetListAsync("FeatureSliders", token.AccessToken);

            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
    }
}
