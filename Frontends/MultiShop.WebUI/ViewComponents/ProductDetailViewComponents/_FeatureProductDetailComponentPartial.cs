using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _FeatureProductDetailComponentPartial : ViewComponent
    {
        private readonly IDataProtector _dataProtector;
        private readonly IProductReadApiService _productReadApiService;
        public _FeatureProductDetailComponentPartial(IDataProtectionProvider dataProtection, IProductReadApiService productReadApiService)
        {
            _dataProtector = dataProtection.CreateProtector("FeatureProductDefaultViewComponent");
            _productReadApiService = productReadApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = _dataProtector.Unprotect(id);
            var value = await _productReadApiService.GetByIdAsync("Products", dataId);
            if (value is not null)
            {
                return View(value);
            }
            return View(null);
        }
    }
}
