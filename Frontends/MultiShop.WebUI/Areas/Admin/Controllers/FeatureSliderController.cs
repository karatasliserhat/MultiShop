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
    public class FeatureSliderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFeatureSliderCommandApiService _featureSliderCommandApiService;
        private readonly IFeatureSliderReadApiService _featureSliderReadApiService;
        private readonly IDataProtector _dataProtector;

        public FeatureSliderController(IMapper mapper, IFeatureSliderCommandApiService featureSliderCommandApiService, IFeatureSliderReadApiService featuresliderReadApiService, IDataProtectionProvider dataProtector)
        {
            _mapper = mapper;
            _featureSliderCommandApiService = featureSliderCommandApiService;
            _featureSliderReadApiService = featuresliderReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminFeatureSliderController");
        }
        public void SelectTrueFalse()
        {
            ViewBag.SelectTrueFalse = new SelectList(Enum.GetValues(typeof(TrueFalse)));
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Slider Görseller";
            ViewBag.v3 = "Öne Çıkan Slider Görsel Listesi";
            string token = "";

            var result = await _featureSliderReadApiService.GetListAsync("FeatureSliders", token);
            if (result.Count > 0)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.FeatureSliderId.ToString()));
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Slider Görseller";
            ViewBag.v3 = "Yeni Öne Çıkan Slider Görsel Girişi";

            SelectTrueFalse();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var result = await _featureSliderCommandApiService.CreateAsync("FeatureSliders", createFeatureSliderDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectTrueFalse();
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Slider Görseller";
            ViewBag.v3 = "Öne Çıkan Slider Görsel Güncelleme";
            var result = _mapper.Map<UpdateFeatureSliderDto>(await _featureSliderReadApiService.GetByIdAsync("FeatureSliders", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                SelectTrueFalse();
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var result = await _featureSliderCommandApiService.UpdateAsync("FeatureSliders", updateFeatureSliderDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectTrueFalse();
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _featureSliderCommandApiService.RemoveAsync("FeatureSliders", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
