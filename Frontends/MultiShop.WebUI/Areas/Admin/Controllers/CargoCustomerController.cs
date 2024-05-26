using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class CargoCustomerController : Controller
    {
        private readonly ICargoCustomerReadApiService _cargoCustomerReadApiService;
        private readonly IDataProtector _dataProtector;

        public CargoCustomerController(ICargoCustomerReadApiService cargoCustomerReadApiService, IDataProtectionProvider dataProtector)
        {
            _cargoCustomerReadApiService = cargoCustomerReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminUserController");
        }
        public void ViewBagList(string v0, string v1, string v2, string v3)
        {
            ViewBag.v0 = v0;
            ViewBag.v1 = v1;
            ViewBag.v2 = v2;
            ViewBag.v3 = v3;
        }
        public async Task<IActionResult> GetCargoCustomerByUserId(string id)
        {
            ViewBagList("Kargo Müşteri İşlemleri", "Ana Sayfa", "Kargo Müşterileri", "Kargo Müşterisi");

            var result = await _cargoCustomerReadApiService.GetCargoCustomerWithUserId(_dataProtector.Unprotect(id));
            return View(result);
        }
    }
}
