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
            var result = await _identityCommandApiService.LoginAsync(userLoginDto);

            if (result != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(result.Token);
                var claims = token.Claims.ToList();

                if (result.Token is not null)
                {
                    claims.Add(new Claim("multishoptoken", result.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                    var autprops = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = result.ExpireDate
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), autprops);
                    var id = _loginService.GetUserId;
                    return RedirectToAction(nameof(Index), "Default");
                }
            }

            return View();

        }

        //public IActionResult SignIn()
        //{
        //    return View();
        //}
        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.UserName = "serhatkaratasli";
            signInDto.Password = "Password12*";

            await _identitySignInService.SignInAsync(signInDto);
            return RedirectToAction(nameof(Index), "Test");

        }
    }
}
