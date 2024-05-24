using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyReadApiService _cargoCompanyReadApiService;
        private readonly ICargoCompanyCommandApiService _cargoCompanyCommandApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IMapper _mapper;
        public CargoCompanyController(ICargoCompanyReadApiService cargoCompanyReadApiService, ICargoCompanyCommandApiService cargoCompanyCommandApiService, IDataProtectionProvider dataProtector, IMapper mapper)
        {
            _cargoCompanyReadApiService = cargoCompanyReadApiService;
            _cargoCompanyCommandApiService = cargoCompanyCommandApiService;
            _dataProtector = dataProtector.CreateProtector("AdminCargoCompanyController");
            _mapper = mapper;
        }
        public void ViewBagList(string v0, string v1, string v2, string v3)
        {
            ViewBag.v0 = v0;
            ViewBag.v1 = v1;
            ViewBag.v2 = v2;
            ViewBag.v3 = v3;
        }
        public async Task<IActionResult> Index()
        {
            ViewBagList("Kargo Şirket İşlemleri", "Ana Sayfa", "Kargo Şirketleri", "Kargo Şirket Listesi");

            var result = await _cargoCompanyReadApiService.GetListAsync("CargoCompanies");
            if (result is { Count: > 0 })
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.CargoCompanyId.ToString()));
                return View(result);

            }
            return null;
        }
        public IActionResult CreateCargoCompany()
        {
            ViewBagList("Kargo Şirket İşlemleri", "Ana Sayfa", "Kargo Şirketleri", "Kargo Şirket Ekleme");

            return View(new CreateCargoCompanyDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var result = await _cargoCompanyCommandApiService.CreateAsync("CargoCompanies", createCargoCompanyDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBagList("Kargo Şirket İşlemleri", "Ana Sayfa", "Kargo Şirketleri", "Kargo Şirket Güncelleme");

            var value = _mapper.Map<UpdateCargoCompanyDto>(await _cargoCompanyReadApiService.GetByIdAsync("CargoCompanies", int.Parse(_dataProtector.Unprotect(id))));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var result = await _cargoCompanyCommandApiService.UpdateAsync("CargoCompanies", updateCargoCompanyDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _cargoCompanyCommandApiService.RemoveAsync("CargoCompanies", int.Parse(_dataProtector.Unprotect(id)));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
    }
}
