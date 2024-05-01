using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class BrandController : Controller
    {
        private readonly IBrandCommandApiService _commandApiService;
        private readonly IBrandReadApiService _brandReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IMapper _mapper;

        public BrandController(IBrandCommandApiService commandApiService, IBrandReadApiService brandReadApiService, IDataProtectionProvider dataProtector, IMapper mapper)
        {
            _commandApiService = commandApiService;
            _brandReadApiService = brandReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminBrandController");
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
            var result = await _brandReadApiService.GetListAsync("Brands");
            if (result.Count > 0)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.BrandId.ToString()));
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Yeni Marka Girişi";
            return View(new CreateBrandDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var result = await _commandApiService.CreateAsync("Brands", createBrandDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Güncelleme";

            var result = _mapper.Map<UpdateBrandDto>(await _brandReadApiService.GetByIdAsync("Brands", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto updateBrandDto)
        {
            var result = await _commandApiService.UpdateAsync("Brands", updateBrandDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _commandApiService.RemoveAsync("Brands", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
