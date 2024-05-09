using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrderAddressCommandApiService _commandApiService;
        private readonly IBasketReadApiService _basketReadApiService;
        private readonly IMapper _mapper;
        private readonly IDataProtector _basketDataProtector;

        public OrderController(IOrderAddressCommandApiService commandApiService, IBasketReadApiService basketReadApiService, IMapper mapper, IDataProtectionProvider dataProtection)
        {
            _commandApiService = commandApiService;
            _basketReadApiService = basketReadApiService;
            _mapper = mapper;
            _basketDataProtector = dataProtection.CreateProtector("ShoppingCartController");
        }

        public async Task<IActionResult> Index(string rate)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Siparişler";
            ViewBag.v2 = "Sipariş İşlemleri";

            var basketValue = await _basketReadApiService.GetBasketAsync();
            basketValue.DiscountRate = rate is not null ? int.Parse(_basketDataProtector.Unprotect(rate)) : 0;
            var basketDiscountCalculateValue = _mapper.Map<BasketDiscountCalculateDto>(basketValue);
            ViewBag.BasketDiscountCalculate = basketDiscountCalculateValue;
            return View();
        }

        public async Task<IActionResult> AdressCreate(CreateAddressDto createAddressDto)
        {
            var result = await _commandApiService.CreateAsync("addresses", createAddressDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(createAddressDto);
        }
    }
}
