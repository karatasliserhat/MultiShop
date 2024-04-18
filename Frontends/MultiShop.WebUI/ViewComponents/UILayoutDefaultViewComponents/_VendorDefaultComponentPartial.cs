using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IBrandReadApiService _brandReadApiService;

        public _VendorDefaultComponentPartial(IBrandReadApiService brandReadApiService)
        {
            _brandReadApiService = brandReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _brandReadApiService.GetListAsync("Brands");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
