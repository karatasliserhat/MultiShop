using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.dataId=id;
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ürünler";
            ViewBag.v2 = "Ürün Listesi";
            return View();
        }

        public IActionResult ProductDetail()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v2 = "Ürün Detayları";
            return View();
        }
    }
}
