using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly ICategoryCommandApiService _categoryCommandApiService;
        private readonly IMapper _mapper;
        public CategoryController(IDataProtectionProvider dataProtector, ICategoryReadApiService categoryReadApiService, ICategoryCommandApiService categoryCommandApiService, IMapper mapper)
        {
            _dataProtector = dataProtector.CreateProtector("AdminCategoryController");
            _categoryReadApiService = categoryReadApiService;
            _categoryCommandApiService = categoryCommandApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";

            var result = await _categoryReadApiService.GetListAsync("Categories");
            if (result.Count > 0)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.CategoryId.ToString()));
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryCommandApiService.CreateAsync("Categories", createCategoryDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme";

            var result = _mapper.Map<UpdateCategoryDto>(await _categoryReadApiService.GetByIdAsync("Categories", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryCommandApiService.UpdateAsync("Categories", updateCategoryDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _categoryCommandApiService.RemoveAsync("Categories", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
