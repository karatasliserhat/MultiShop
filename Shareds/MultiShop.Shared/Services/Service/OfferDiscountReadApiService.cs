using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OfferDiscountReadApiService : ApiReadService<ResultOfferDiscountDto>, IOfferDiscountReadApiService
    {
        public OfferDiscountReadApiService(HttpClient client, IAuthorizationTokenApiService authorizationTokenApiService) : base(client, authorizationTokenApiService)
        {
        }
    }
}
