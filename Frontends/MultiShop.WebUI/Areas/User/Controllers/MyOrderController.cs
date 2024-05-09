using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[Controller]/[Action]")]
    public class MyOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
