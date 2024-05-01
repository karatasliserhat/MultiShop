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
        public void ViewBagList(string v0, string v1, string v2, string v3)
        {
            ViewBag.v0 = v0;
            ViewBag.v1 = v1;
            ViewBag.v2 = v2;
            ViewBag.v3 = v3;
        }
        public async Task<IActionResult> Index()
        {
            ViewBagList("Kategori İşlemleri", "Ana Sayfa", "Kategoriler", "Kategori Listesi");

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
            ViewBagList("Kategori İşlemleri", "Ana Sayfa", "Kategoriler", "Yeni Kategori Girişi");
            return View(new CreateCategoryDto());
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
            ViewBagList("Kategori İşlemleri", "Ana Sayfa", "Kategoriler", "Kategori Güncelleme");
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
