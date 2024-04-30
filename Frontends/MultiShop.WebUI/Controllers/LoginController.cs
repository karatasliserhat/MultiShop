using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityCommandApiService _identityCommandApiService;
        private readonly ILoginService _loginService;
        private readonly IIdentitySignInService _identitySignInService;
        public LoginController(IIdentityCommandApiService identityCommandApiService, ILoginService loginService, IIdentitySignInService identitySignInService)
        {
            _identityCommandApiService = identityCommandApiService;
            _loginService = loginService;
            _identitySignInService = identitySignInService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserLoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
          
            return View();

        }

        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.UserName = "serhatkaratasli";
            signInDto.Password = "Password12*";
            await _identitySignInService.SignInAsync(signInDto);
            return RedirectToAction(nameof(Index), "User");

        }
    }
}
