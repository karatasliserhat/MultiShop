using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class DiscountCommandApiService : ApiCommandService<UpdateCouponDto, CreateCouponDto>, IDiscountCommandApiService
    {
        public DiscountCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
