using MultiShop.DtoLayer.OrderDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IOrderDetailCommandApiService:IApiCommandService<UpdateOrderDetailDto,CreateOrderDetailDto>
    {
    }
}
