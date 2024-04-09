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
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;
        private readonly IMapper _mapper;
        public CargoOperationsController(ICargoOperationService CargoOperationService, IMapper mapper)
        {
            _CargoOperationService = CargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            return Ok(_mapper.Map<List<ResultCargoOperationDto>>(await _CargoOperationService.GetAllAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            await _CargoOperationService.CreateAsync(_mapper.Map<CargoOperation>(createCargoOperationDto));
            return Ok("Kargo Hareketi Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById(int id)
        {
            return Ok(_mapper.Map<GetCargoOperationDto>(await _CargoOperationService.GetByIdAsync(id)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            await _CargoOperationService.DeleteAsync(id);
            return Ok("Kargo Hareketi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _CargoOperationService.UpdateAsync(_mapper.Map<CargoOperation>(updateCargoOperationDto));

            return Ok("Kargo Hareketi Güncellendi");
        }
    }
}
