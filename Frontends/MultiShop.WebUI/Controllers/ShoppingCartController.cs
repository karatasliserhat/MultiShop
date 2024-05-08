using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketCommandApiService _basketCommandApiService;
        private readonly IProductReadApiService _productReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IDataProtector _basketDataProtector;
        private readonly IDataProtector _discountControllerProtect;
        private readonly IBasketReadApiService _basketReadApiService;
        private readonly IMapper _mapper;
        public ShoppingCartController(IBasketCommandApiService basketCommandApiService, IDataProtectionProvider dataProtection, IMapper mapper, IProductReadApiService productReadApiService, IBasketReadApiService basketReadApiService)
        {
            _basketCommandApiService = basketCommandApiService;
            _dataProtector = dataProtection.CreateProtector("FeatureProductDefaultViewComponent");
            _discountControllerProtect = dataProtection.CreateProtector("DiscountController");
            _mapper = mapper;
            _productReadApiService = productReadApiService;
            _basketDataProtector = dataProtection.CreateProtector("ShoppingCartController");
            _basketReadApiService = basketReadApiService;
        }

        public async Task<IActionResult> Index(string rate)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ürünler";
            ViewBag.v2 = "Sepetim";
            var basketValue = await _basketReadApiService.GetBasketAsync();
            basketValue.DiscountRate = rate is not null ? int.Parse(_discountControllerProtect.Unprotect(rate)) : 0;
            var basketDiscountCalculateValue = _mapper.Map<BasketDiscountCalculateDto>(basketValue);
            ViewBag.BasketDiscountCalculate = basketDiscountCalculateValue;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var product = await _productReadApiService.GetByIdAsync("products", _dataProtector.Unprotect(productId));
            await _basketCommandApiService.AddBasketItem(_mapper.Map<BasketItemDto>(product));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketCommandApiService.RemoveBasketItem(_basketDataProtector.Unprotect(productId));
            return RedirectToAction(nameof(Index));
        }
    }
}
