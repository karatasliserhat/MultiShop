using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _DescriptionProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductDetailReadApiService _productDetailReadApiService;
        private readonly IDataProtector _dataProtector;

        public _DescriptionProductDetailComponentPartial(IProductDetailReadApiService productDetailReadApiService, IDataProtectionProvider dataProtector)
        {
            _productDetailReadApiService = productDetailReadApiService;
            _dataProtector = dataProtector.CreateProtector("FeatureProductDefaultViewComponent");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var result = await _productDetailReadApiService.GetProductDetailByProductIdAsync(_dataProtector.Unprotect(id));
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }

}
