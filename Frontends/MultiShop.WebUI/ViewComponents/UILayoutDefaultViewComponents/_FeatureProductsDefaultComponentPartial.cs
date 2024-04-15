using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial:ViewComponent
    {
        private readonly IProductReadApiService _productReadApiService;

        public _FeatureProductsDefaultComponentPartial(IProductReadApiService productReadApiService)
        {
            _productReadApiService = productReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _productReadApiService.GetListAsync("Products");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
