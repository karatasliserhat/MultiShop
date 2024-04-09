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
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;
        public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            return Ok(_mapper.Map<List<ResultCargoCompanyDto>>(await _cargoCompanyService.GetAllAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateAsync(_mapper.Map<CargoCompany>(createCargoCompanyDto));
            return Ok("Kargo Şirketi Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyById(int id)
        {
            return Ok(_mapper.Map<GetCargoCompanyDto>(await _cargoCompanyService.GetByIdAsync(id)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteAsync(id);
            return Ok("Kargo Şirketi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateAsync(_mapper.Map<CargoCompany>(updateCargoCompanyDto));

            return Ok("Kargo Şirketi Güncellendi");
        }
    }
}
