using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class SpecialOfferReadApiService : ApiReadService<ResultSpecialOfferDto>, ISpecialOfferReadApiService
    {
        public SpecialOfferReadApiService(HttpClient client) : base(client)
        {
        }
    }
}
