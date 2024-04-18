using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _OfferDiscountService;

        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _OfferDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            return Ok(await _OfferDiscountService.GetAllOfferDiscountAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            return Ok(await _OfferDiscountService.GetByIdOfferDiscountAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("İndirim Teklifi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("İndirim Teklifi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _OfferDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("İndirim Teklifi Silindi");

        }
    }
}
