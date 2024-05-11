using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityCommandApiService _identityCommandApiService;
        private readonly IGetUserService _getUserService;
        private readonly IIdentitySignInService _identitySignInService;
        public LoginController(IIdentityCommandApiService identityCommandApiService, IGetUserService getUserService, IIdentitySignInService identitySignInService)
        {
            _identityCommandApiService = identityCommandApiService;
            _getUserService = getUserService;
            _identitySignInService = identitySignInService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SignInDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identitySignInService.SignInAsync(signInDto);
            return RedirectToAction(nameof(Index), "User");

        }

    }
}
