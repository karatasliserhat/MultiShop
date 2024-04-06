using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
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
