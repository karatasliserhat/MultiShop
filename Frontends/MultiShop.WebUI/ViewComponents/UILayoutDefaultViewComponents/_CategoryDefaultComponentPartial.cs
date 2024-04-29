using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UILayoutDefaultViewComponents
{
    public class _CategoryDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public _CategoryDefaultComponentPartial(ICategoryReadApiService categoryReadApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _categoryReadApiService = categoryReadApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();

            var result = await _categoryReadApiService.GetListAsync("Categories", token.AccessToken);
            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
    }
}
