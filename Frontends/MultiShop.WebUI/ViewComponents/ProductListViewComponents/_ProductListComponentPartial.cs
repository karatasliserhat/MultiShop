using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductReadApiService _productReadApiService;
        private readonly IDataProtector _dataprotector;
        public _ProductListComponentPartial(IProductReadApiService productReadApiService, IDataProtectionProvider dataprotector)
        {
            _productReadApiService = productReadApiService;
            _dataprotector = dataprotector.CreateProtector("CategoryNavbarViewComponent");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = id == null ? "abcçdefghıijklmno" : _dataprotector.Unprotect(id);

            var values = await _productReadApiService.ProductListWithCategoryByCategoryId(dataId);
            if (!values.Any())
            {
                values = await _productReadApiService.GetProductsWithCategoryAsync();
                return View(values);
            }

            return View(values);
        }
    }
}
