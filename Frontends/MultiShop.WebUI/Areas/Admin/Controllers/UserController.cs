using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class UserController : Controller
    {
        private readonly IIdentityReadApiService _identityReadApiService;
        private readonly IDataProtector _dataProtector;
        public UserController(IIdentityReadApiService identityReadApiService, IDataProtectionProvider dataProtector)
        {
            _identityReadApiService = identityReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminUserController");
        }
        public void ViewBagList(string v0, string v1, string v2, string v3)
        {
            ViewBag.v0 = v0;
            ViewBag.v1 = v1;
            ViewBag.v2 = v2;
            ViewBag.v3 = v3;
        }
        public async Task<IActionResult> GetUserAll()
        {
            ViewBagList("Kullanıcı İşlemleri", "Ana Sayfa", "Kullanıcılar", "Kullanıcı Listesi");

            var users = await _identityReadApiService.GetUserListAsync();
            users.ForEach(x => x.DataProtect = _dataProtector.Protect(x.Id));
            return View(users);
        }
    }
}
