using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountReadApiService _offerDiscountReadApiService;
        public _OfferDiscountDefaultComponentPartial(IOfferDiscountReadApiService offerDiscountReadApiService)
        {
            _offerDiscountReadApiService = offerDiscountReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _offerDiscountReadApiService.GetListAsync("OfferDiscounts");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
