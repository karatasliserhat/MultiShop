using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.NavbarUILayoutViewComponents
{
    public class _CategoriesNavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly IDataProtector _dataProtector;
        public _CategoriesNavbarUILayoutComponentPartial(ICategoryReadApiService categoryReadApiService, IDataProtectionProvider dataProtector)
        {
            _categoryReadApiService = categoryReadApiService;
            _dataProtector = dataProtector.CreateProtector("CategoryNavbarViewComponent");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _categoryReadApiService.GetListAsync("Categories");
            result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.CategoryId));
            if (result is not null)
            {
                return View(result);

            }
            return View(null);
        }
    }
}
