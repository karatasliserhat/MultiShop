using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllDiscountCouponAsync();
        Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id);
        Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<ResultCouponDto> GetCouponDetailWithCouponCode(string code);
        Task<GetByCodeCouponRateDto> GetCouponRateWithCouponCode(string code);
    }
}
