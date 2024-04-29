using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _SpeacialOfferDefaultCarouselComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferReadApiService _specialOfferReadApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _SpeacialOfferDefaultCarouselComponentPartial(ISpecialOfferReadApiService specialOfferReadApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _specialOfferReadApiService = specialOfferReadApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _specialOfferReadApiService.GetListAsync("SpecialOffers", token.AccessToken);
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
