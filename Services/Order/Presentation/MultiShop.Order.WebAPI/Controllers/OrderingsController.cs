using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.MediatR.Commands;
using MultiShop.Order.Application.Features.MediatR.Queries;
using MultiShop.Order.Application.Features.MediatR.Queries.OrderingQueries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public OrderingsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderingList()
        {
            return Ok(await _mediatR.Send(new GetOrderingQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            return Ok(await _mediatR.Send(new GetOrderingByIdQuery(id)));
        }
        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetOrderingByUserId(string userId)
        {
            return Ok(await _mediatR.Send(new GetOrderingByUserIdQuery(userId)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediatR.Send(createOrderingCommand);
            return Ok("Sipariş Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediatR.Send(updateOrderingCommand);
            return Ok("Sipariş Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediatR.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş Silindi");
        }
    }
}
