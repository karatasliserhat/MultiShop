using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _CategoryDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryReadApiService _categoryReadApiService;

        public _CategoryDefaultComponentPartial(ICategoryReadApiService categoryReadApiService)
        {
            _categoryReadApiService = categoryReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _categoryReadApiService.GetListAsync("Categories");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
