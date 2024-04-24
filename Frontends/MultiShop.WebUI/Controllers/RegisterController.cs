using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IIdentityCommandApiService _identityCommandApiService;

        public RegisterController(IIdentityCommandApiService identityCommandApiService)
        {
            _identityCommandApiService = identityCommandApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RegisterDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            if (registerDto.Password ==registerDto.ConfirmPassword)
            {
                var result = await _identityCommandApiService.RegisterUserAsync(registerDto);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), "Default");
                }
            }
           
            return View();
        }
    }
}
