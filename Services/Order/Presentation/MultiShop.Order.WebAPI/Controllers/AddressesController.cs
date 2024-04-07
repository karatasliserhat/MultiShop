using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.MediatR.Commands;
using MultiShop.Order.Application.Features.MediatR.Queries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AddressesController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressList()
        {
            return Ok(await _mediatR.Send(new GetAdressQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            return Ok(await _mediatR.Send(new GetAddressByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _mediatR.Send(createAddressCommand);
            return Ok("Adres Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _mediatR.Send(updateAddressCommand);
            return Ok("Adres Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _mediatR.Send(new RemoveAddressCommand(id));
            return Ok("Adres Bilgisi Silindi");
        }
    }
}
