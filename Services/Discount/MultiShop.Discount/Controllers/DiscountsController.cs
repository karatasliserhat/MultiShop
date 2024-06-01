using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoupon()
        {
            return Ok(await _discountService.GetAllDiscountCouponAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCoupon(int id)
        {
            return Ok(await _discountService.GetByIdDiscountCouponAsync(id));
        }

        [HttpGet("[Action]/{Code}")]
        public async Task<IActionResult> GetCouponDetailWithCode(string Code)
        {
            var values = await _discountService.GetCouponDetailWithCouponCode(Code);
            if (values is null)
            {

                return Ok(values = new ResultCouponDto());
            }

            return Ok(values);
        }
        [HttpGet("[Action]/{Code}")]
        public async Task<IActionResult> GetCouponRateWithCode(string Code)
        {
            var values = await _discountService.GetCouponRateWithCouponCode(Code);
            return Ok(values);
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetDiscountCount()
        {
            var values = await _discountService.GetDiscountCountAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Kupon Güncellendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Silindi");
        }
    }
}
