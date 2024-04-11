using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ürünler";
            ViewBag.v2 = "Sepetim";
            return View();
        }
    }
}
