using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.MediatR.Commands;
using MultiShop.Order.Application.Features.MediatR.Queries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public OrderDetailsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailList()
        {
            return Ok(await _mediatR.Send(new GetAdressQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            return Ok(await _mediatR.Send(new GetOrderDetailByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _mediatR.Send(createOrderDetailCommand);
            return Ok("Sipariş Detay Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _mediatR.Send(updateOrderDetailCommand);
            return Ok("Sipariş Detay Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _mediatR.Send(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş Detay Bilgisi Silindi");
        }
    }
}
