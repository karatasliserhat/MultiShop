using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;
        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            return Ok(await _FeatureSliderService.GetAllFeatureSliderAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            return Ok(await _FeatureSliderService.GetByIdFeatureSliderAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne Çıkan Fotoğraf Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne Çıkan Fotoğraf  Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne Çıkan Fotoğraf  Silindi");

        }
    }
}
