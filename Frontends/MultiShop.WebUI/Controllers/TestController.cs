using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly ICategoryCommandApiService _categoryCommandApiService;
        private readonly IMapper _mapper;
        private readonly IAuthorizationTokenApiService _authorizationTokenApiService;
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;
        public TestController(IDataProtectionProvider dataProtector, ICategoryReadApiService categoryReadApiService, ICategoryCommandApiService categoryCommandApiService, IMapper mapper, IAuthorizationTokenApiService authorizationTokenApiService, IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _dataProtector = dataProtector.CreateProtector("AdminCategoryController");
            _categoryReadApiService = categoryReadApiService;
            _categoryCommandApiService = categoryCommandApiService;
            _mapper = mapper;
            _authorizationTokenApiService = authorizationTokenApiService;
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }



        public async Task<IActionResult> Index()
        {

            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";

            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();
            var result = await _categoryReadApiService.GetListAsync("Categories", token.AccessToken);
            if (result.Count > 0)
            {

                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.CategoryId.ToString()));
                return View(result);
            }
            return View();
        }
    }
}
