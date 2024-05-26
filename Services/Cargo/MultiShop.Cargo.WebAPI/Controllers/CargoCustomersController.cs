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
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _CargoCustomerService;
        private readonly IMapper _mapper;
        public CargoCustomersController(ICargoCustomerService CargoCustomerService, IMapper mapper)
        {
            _CargoCustomerService = CargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCustomerList()
        {
            return Ok(_mapper.Map<List<ResultCargoCustomerDto>>(await _CargoCustomerService.GetAllAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _CargoCustomerService.CreateAsync(_mapper.Map<CargoCustomer>(createCargoCustomerDto));
            return Ok("Kargo Müşterisi Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerById(int id)
        {
            return Ok(_mapper.Map<GetCargoCustomerDto>(await _CargoCustomerService.GetByIdAsync(id)));
        }
        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetCargoCustomerWithUserId(string userId)
        {
            var result = _mapper.Map<GetCargoCustomerWithUserIdDto>(await _CargoCustomerService.GetCarCustomerWithUserIdAsync(userId, new CancellationToken()));
            if (result is { Address: not null, City: not null })
            {
                return Ok(result);

            }
            return Ok(new GetCargoCustomerWithUserIdDto());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            await _CargoCustomerService.DeleteAsync(id);
            return Ok("Kargo Müşterisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _CargoCustomerService.UpdateAsync(_mapper.Map<CargoCustomer>(updateCargoCustomerDto));

            return Ok("Kargo Müşterisi Güncellendi");
        }
    }
}
