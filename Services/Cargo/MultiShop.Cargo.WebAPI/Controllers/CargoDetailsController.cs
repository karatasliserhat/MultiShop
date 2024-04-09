using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;
        private readonly IMapper _mapper;
        public CargoDetailsController(ICargoDetailService CargoDetailService, IMapper mapper)
        {
            _CargoDetailService = CargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            return Ok(_mapper.Map<List<ResultCargoDetailDto>>(await _CargoDetailService.GetAllAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            await _CargoDetailService.CreateAsync(_mapper.Map<CargoDetail>(createCargoDetailDto));
            return Ok("Kargo Detayı Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById(int id)
        {
            return Ok(_mapper.Map<GetCargoDetailDto>(await _CargoDetailService.GetByIdAsync(id)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _CargoDetailService.DeleteAsync(id);
            return Ok("Kargo Detayı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _CargoDetailService.UpdateAsync(_mapper.Map<CargoDetail>(updateCargoDetailDto));

            return Ok("Kargo Detayı Güncellendi");
        }
    }
}
