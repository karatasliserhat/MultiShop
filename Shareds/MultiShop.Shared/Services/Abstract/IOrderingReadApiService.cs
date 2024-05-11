using MultiShop.DtoLayer.OrderDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IOrderingReadApiService:IApiReadService<ResultOrderingDto>
    {
        Task<List<GetOrderingByUserIdDto>> GetAllOrderingByUserId(string userId);
    }
}
