using MultiShop.DtoLayer.OrderDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IOrderAddressCommandApiService:IApiCommandService<UpdateAddressDto,CreateAddressDto>
    {
    }
}
