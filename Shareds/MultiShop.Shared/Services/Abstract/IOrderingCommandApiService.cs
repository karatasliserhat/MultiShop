using MultiShop.DtoLayer.OrderDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IOrderingCommandApiService:IApiCommandService<UpdateOrderingDto,CreateOrderingDto>
    {
    }
}
