using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountReadApiService _discountReadApiService;
        private readonly IDataProtector _dataProtector;
        public DiscountController(IDiscountReadApiService discountReadApiService, IDataProtectionProvider dataProtector)
        {
            _discountReadApiService = discountReadApiService;
            _dataProtector = dataProtector.CreateProtector("DiscountController");
        }

        public async Task<IActionResult> GetDiscountDetailCode(GetDiscountCodeDto getDiscountCodeDto)
        {

            var discountValue = await _discountReadApiService.GetDiscountCouponDetailWihtCodeAsync(getDiscountCodeDto.Code);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { rate = _dataProtector.Protect(discountValue.Rate.ToString()) });

        }
    }
}
