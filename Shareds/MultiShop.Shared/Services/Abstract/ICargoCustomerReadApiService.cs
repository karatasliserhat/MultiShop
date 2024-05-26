using MultiShop.DtoLayer.CargoDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface ICargoCustomerReadApiService
    {
        Task<GetCargoCustomerWithUserIdDto> GetCargoCustomerWithUserId(string userId);
    }
}
