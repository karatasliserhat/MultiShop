using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IDiscountReadApiService:IApiReadService<ResultCouponDto>
    {
        Task<GetByCodeCouponRateDto> GetDiscountCouponRateWihtCodeAsync(string code);
        Task<ResultCouponDto> GetDiscountCouponDetailWihtCodeAsync(string code);
        Task<int> GetDiscountCount();
    }
}
