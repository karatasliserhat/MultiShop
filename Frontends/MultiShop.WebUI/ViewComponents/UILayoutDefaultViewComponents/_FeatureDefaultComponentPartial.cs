using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureReadApiService _featureReadApiService;

        public _FeatureDefaultComponentPartial(IFeatureReadApiService featureReadApiService)
        {
            _featureReadApiService = featureReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _featureReadApiService.GetListAsync("Features");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
