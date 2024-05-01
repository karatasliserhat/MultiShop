using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _SpeacialOfferDefaultCarouselComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferReadApiService _specialOfferReadApiService;
        public _SpeacialOfferDefaultCarouselComponentPartial(ISpecialOfferReadApiService specialOfferReadApiService)
        {
            _specialOfferReadApiService = specialOfferReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _specialOfferReadApiService.GetListAsync("SpecialOffers");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
