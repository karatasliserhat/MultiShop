using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class ProductController : Controller
    {

        private readonly IProductCommandApiService _productCommandApiService;
        private readonly IProductReadApiService _productReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly IMapper _mapper;

        public ProductController(IProductCommandApiService productCommandApiService, IProductReadApiService productReadApiService, IDataProtectionProvider dataProtector, IMapper mapper, ICategoryReadApiService categoryReadApiService)
        {
            _productCommandApiService = productCommandApiService;
            _productReadApiService = productReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminProductController");
            _mapper = mapper;
            _categoryReadApiService = categoryReadApiService;
        }

        private async Task GetCategorySelectList()
        {
            var data = await _categoryReadApiService.GetListAsync("Categories");

            ViewBag.Category = new SelectList(data, "CategoryId", "Name");
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var response = await _productReadApiService.GetProductsWithCategoryAsync();
            if (response.Count > 0)
            {
                response.ForEach(x => x.DataProtect = _dataProtector.Protect(x.ProductId));
                return View(response);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Yeni Ürün Girişi";

            await GetCategorySelectList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var result = await _productCommandApiService.CreateAsync("Products", createProductDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            await GetCategorySelectList();
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productCommandApiService.RemoveAsync("Products", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme";

            await GetCategorySelectList();

            var result = _mapper.Map<UpdateProductDto>(await _productReadApiService.GetByIdAsync("Products", _dataProtector.Unprotect(id)));

            if (result is not null)
            {
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var result = await _productCommandApiService.UpdateAsync("Products", updateProductDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            await GetCategorySelectList();
            return View();
        }
    }
}
