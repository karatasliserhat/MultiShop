using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailCommandApiService _productDetailCommandApiService;
        private readonly IProductDetailReadApiService _productDetailReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IDataProtector _productDetailDataProtector;
        private readonly IMapper _mapper;

        public ProductDetailController(IProductDetailCommandApiService productDetailCommandApiService, IProductDetailReadApiService productDetailReadApiService, IDataProtectionProvider dataProtector, IMapper mapper)
        {
            _productDetailCommandApiService = productDetailCommandApiService;
            _productDetailReadApiService = productDetailReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminProductController");
            _productDetailDataProtector = dataProtector.CreateProtector("AdminProductDetailController");
            _mapper = mapper;
        }

        public async Task<IActionResult> ProductDetailIndex(string id)
        {
            ViewBag.v0 = "Ürün Detay İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Detayları";
            ViewBag.v3 = "Ürün Detay Bilgisi";
            ViewBag.dataProductId = id;
            var result = await _productDetailReadApiService.GetProductDetailByProductIdAsync(_dataProtector.Unprotect(id));
            if (result is not null)
            {
                result.DataProtect = _productDetailDataProtector.Protect(result.ProductDetailId);
                return View(result);
            }
            return View(null);
        }
        [HttpGet]
        public IActionResult CreateProductDetail(string id)
        {
            ViewBag.v0 = "Ürün Detay İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Detayları";
            ViewBag.v3 = "Ürün Detay Ekleme";
            ViewBag.ProductId = _dataProtector.Unprotect(id);
            return View(new CreateProductDetailDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {

            var result = await _productDetailCommandApiService.CreateAsync("ProductDetails", createProductDetailDto);
            return RedirectToAction(nameof(ProductDetailIndex), new { id = _dataProtector.Protect(createProductDetailDto.ProductId) });
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Ürün Detay İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Detayları";
            ViewBag.v3 = "Ürün Detay Güncelleme";
            var result = await _productDetailReadApiService.GetByIdAsync("ProductDetails", _productDetailDataProtector.Unprotect(id));

            if (result is not null)
            {
                return View(_mapper.Map<UpdateProductDetailDto>(result));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDetailDto updateProductDetailDto)
        {
            var result = await _productDetailCommandApiService.UpdateAsync("ProductDetails", updateProductDetailDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductDetailIndex), new { id = _dataProtector.Protect(updateProductDetailDto.ProductId) });
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var productDetail = await _productDetailReadApiService.GetByIdAsync("ProductDetails", _productDetailDataProtector.Unprotect(id));

            var result = await _productDetailCommandApiService.RemoveAsync("ProductDetails", productDetail.ProductDetailId);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductDetailIndex), new { id = _dataProtector.Protect(productDetail.ProductId) });
            }
            return View();
        }
    }
}
