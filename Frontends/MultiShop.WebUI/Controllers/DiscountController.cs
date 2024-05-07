using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountReadApiService _discountReadApiService;

        public DiscountController(IDiscountReadApiService discountReadApiService)
        {
            _discountReadApiService = discountReadApiService;
        }

        public async Task<IActionResult> GetDiscountDetailCode(GetDiscountCodeDto getDiscountCodeDto)
        {

            var discountValue = await _discountReadApiService.GetDiscountCouponDetailWihtCodeAsync(getDiscountCodeDto.Code);

            return RedirectToAction(nameof(Index), "ShoppingCart", new { rate = discountValue.Rate });

        }
    }
}
