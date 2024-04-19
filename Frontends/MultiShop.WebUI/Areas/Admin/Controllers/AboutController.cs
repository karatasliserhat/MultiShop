using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AboutController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly IAboutReadApiService _AboutReadApiService;
        private readonly IAboutCommandApiService _AboutCommandApiService;
        private readonly IMapper _mapper;
        public AboutController(IDataProtectionProvider dataProtector, IAboutReadApiService AboutReadApiService, IAboutCommandApiService AboutCommandApiService, IMapper mapper)
        {
            _dataProtector = dataProtector.CreateProtector("AdminAboutController");
            _AboutReadApiService = AboutReadApiService;
            _AboutCommandApiService = AboutCommandApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Hakkımızda İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";

            var result = await _AboutReadApiService.GetListAsync("Abouts");
            if (result.Count > 0)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.AboutId.ToString()));
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            ViewBag.v0 = "Hakkımızda İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Yeni Hakkımızda Girişi";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var result = await _AboutCommandApiService.CreateAsync("Abouts", createAboutDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Hakkımızda İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Güncelleme";

            var result = _mapper.Map<UpdateAboutDto>(await _AboutReadApiService.GetByIdAsync("Abouts", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var result = await _AboutCommandApiService.UpdateAsync("Abouts", updateAboutDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _AboutCommandApiService.RemoveAsync("Abouts", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
