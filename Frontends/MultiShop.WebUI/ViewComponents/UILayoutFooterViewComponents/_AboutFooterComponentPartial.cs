using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutFeatureViewComponents
{
    public class _AboutFooterComponentPartial : ViewComponent
    {
        private readonly IAboutReadApiService _aboutReadApiService;

        public _AboutFooterComponentPartial(IAboutReadApiService aboutReadApiService)
        {
            _aboutReadApiService = aboutReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _aboutReadApiService.GetListAsync("Abouts");
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
