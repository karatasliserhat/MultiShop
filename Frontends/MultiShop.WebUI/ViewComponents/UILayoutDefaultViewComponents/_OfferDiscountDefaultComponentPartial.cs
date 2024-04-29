using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountReadApiService _offerDiscountReadApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _OfferDiscountDefaultComponentPartial(IOfferDiscountReadApiService offerDiscountReadApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _offerDiscountReadApiService = offerDiscountReadApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _offerDiscountReadApiService.GetListAsync("OfferDiscounts", token.AccessToken);
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
