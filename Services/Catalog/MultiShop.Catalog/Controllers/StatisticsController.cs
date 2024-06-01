using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticService;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProductCount()
        {
            return Ok(await _statisticService.GetProductCountAsync());
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetBrandCount()
        {
            return Ok(await _statisticService.GetBrandCountAsync());
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetCategoryCount()
        {
            return Ok(await _statisticService.GetCategoryCountAsync());
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            return Ok(await _statisticService.GetMaxPriceProductNameAsync());
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            return Ok(await _statisticService.GetMinPriceProductNameAsync());
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            return Ok(await _statisticService.GetProductAvgPriceAsync());
        }
    }
}
