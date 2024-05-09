using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ödeme";
            ViewBag.v2 = "Ödeme İşlemi";
            return View();
        }
    }
}
