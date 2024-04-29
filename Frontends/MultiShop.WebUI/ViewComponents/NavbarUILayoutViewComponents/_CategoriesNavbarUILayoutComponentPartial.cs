using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.NavbarUILayoutViewComponents
{
    public class _CategoriesNavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _CategoriesNavbarUILayoutComponentPartial(ICategoryReadApiService categoryReadApiService, IDataProtectionProvider dataProtector, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _categoryReadApiService = categoryReadApiService;
            _dataProtector = dataProtector.CreateProtector("CategoryNavbarViewComponent");
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _categoryReadApiService.GetListAsync("Categories", token.AccessToken);
            result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.CategoryId));
            if (result is not null)
            {
                return View(result);

            }
            return View(null);
        }
    }
}
