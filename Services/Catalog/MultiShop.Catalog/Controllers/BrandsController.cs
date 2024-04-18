using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;
        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            return Ok(await _BrandService.GetAllBrandAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            return Ok(await _BrandService.GetByIdBrandAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _BrandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Marka Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _BrandService.DeleteBrandAsync(id);
            return Ok("Marka Silindi");

        }
    }
}

