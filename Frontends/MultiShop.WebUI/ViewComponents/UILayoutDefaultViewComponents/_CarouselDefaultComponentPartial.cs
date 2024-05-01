using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderReadApiService _featureSliderReadApiService;
        public _CarouselDefaultComponentPartial(IFeatureSliderReadApiService featureSliderReadApiService)
        {
            _featureSliderReadApiService = featureSliderReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = await _featureSliderReadApiService.GetListAsync("FeatureSliders");

            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
    }
}
