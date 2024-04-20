using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ImageSliderProductDetailComponentPartial:ViewComponent
    {
        private readonly IDataProtector _dataProtector;
        private readonly IProductReadApiService _productReadApiService;
        public _ImageSliderProductDetailComponentPartial(IDataProtectionProvider dataProtection, IProductReadApiService productReadApiService)
        {
            _dataProtector = dataProtection.CreateProtector("FeatureProductDefaultViewComponent");
            _productReadApiService = productReadApiService;
        }
        public async  Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = _dataProtector.Unprotect(id);
            var values = await _productReadApiService.GetResultProductWithImagesByProductIdAsync(dataId);
            if (values is not null)
            {
                return View(values);
            }
            return View(null);
        }
    }
}
