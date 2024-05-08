using AutoMapper;
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
        public OrderController(IOrderAddressCommandApiService commandApiService, IBasketReadApiService basketReadApiService, IMapper mapper)
        {
            _commandApiService = commandApiService;
            _basketReadApiService = basketReadApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int rate)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Siparişler";
            ViewBag.v2 = "Sipariş Detayları";

            var basketValue = await _basketReadApiService.GetBasketAsync();
            basketValue.DiscountRate = rate;
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
