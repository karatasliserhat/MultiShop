using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Enums;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class FeatureController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFeatureCommandApiService _FeatureCommandApiService;
        private readonly IFeatureReadApiService _FeatureReadApiService;
        private readonly IDataProtector _dataProtector;

        public FeatureController(IMapper mapper, IFeatureCommandApiService FeatureCommandApiService, IFeatureReadApiService FeatureReadApiService, IDataProtectionProvider dataProtector)
        {
            _mapper = mapper;
            _FeatureCommandApiService = FeatureCommandApiService;
            _FeatureReadApiService = FeatureReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminFeatureController");
        }
        public void SelectTrueFalse()
        {
            ViewBag.SelectTrueFalse = new SelectList(Enum.GetValues(typeof(TrueFalse)));
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alan Listesi";
            var result = await _FeatureReadApiService.GetListAsync("Features");
            if (result.Count > 0)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.FeatureId.ToString()));
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Yeni Öne Çıkan Alan Girişi";

            SelectTrueFalse();
            return View(new CreateFeatureDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var result = await _FeatureCommandApiService.CreateAsync("Features", createFeatureDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectTrueFalse();
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alan Güncelleme";
            var result = _mapper.Map<UpdateFeatureDto>(await _FeatureReadApiService.GetByIdAsync("Features", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                SelectTrueFalse();
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            var result = await _FeatureCommandApiService.UpdateAsync("Features", updateFeatureDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectTrueFalse();
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _FeatureCommandApiService.RemoveAsync("Features", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
