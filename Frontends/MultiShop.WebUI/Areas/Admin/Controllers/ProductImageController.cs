using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class ProductImageController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly IProductImageCommandApiService _productImageCommandApiService;
        private readonly IProductImageReadApiService _productImageReadApiService;
        private readonly IDataProtector _dataProductImage;
        private readonly IMapper _mapper;
        public ProductImageController(IDataProtectionProvider dataProtector, IProductImageCommandApiService productImageCommandApiService, IProductImageReadApiService productImageReadApiService, IMapper mapper)
        {
            _dataProtector = dataProtector.CreateProtector("AdminProductController");
            _productImageCommandApiService = productImageCommandApiService;
            _productImageReadApiService = productImageReadApiService;
            _dataProductImage = dataProtector.CreateProtector("AdminProductImage");
            _mapper = mapper;
        }

        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v0 = "Ürün Fotoğraf İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Fotoğrafları";
            ViewBag.v3 = "Ürün Fotoğraf Listesi";
            var productDataId = _dataProtector.Unprotect(id);
            ViewBag.dataProductId = id;
            var values = await _productImageReadApiService.GetImagesWithProductByProductIdAsync(productDataId);
            if (values.Any())
            {
                values.ForEach(x => x.DataProtect = _dataProductImage.Protect(x.ProductImageId));
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateProductImage(string id)
        {
            ViewBag.v0 = "Ürün Fotoğraf İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Fotoğrafları";
            ViewBag.v3 = "Yeni Ürün Fotoğraf Girişi";
            ViewBag.ProductId = _dataProtector.Unprotect(id);
            return View(new CreateProductImageDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            var result = await _productImageCommandApiService.CreateAsync("ProductImages", createProductImageDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductImageDetail), new { id = _dataProtector.Protect(createProductImageDto.ProductId) });
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Ürün Fotoğraf İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Fotoğrafları";
            ViewBag.v3 = "Ürün Fotoğraf Güncelleme";

            var result = _mapper.Map<UpdateProductImageDto>(await _productImageReadApiService.GetByIdAsync("ProductImages", _dataProductImage.Unprotect(id)));
            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductImageDto updateProductImageDto)
        {
            var result = await _productImageCommandApiService.UpdateAsync("ProductImages", updateProductImageDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductImageDetail), new { id = _dataProtector.Protect(updateProductImageDto.ProductId) });
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var resultProductId = await _productImageReadApiService.GetByIdAsync("ProductImages", _dataProductImage.Unprotect(id));
            var result = await _productImageCommandApiService.RemoveAsync("ProductImages", _dataProductImage.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductImageDetail), new { id = _dataProtector.Protect(resultProductId.ProductId) });
            }
            return View();
        }
    }
}
