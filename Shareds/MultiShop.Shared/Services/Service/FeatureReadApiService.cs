using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class FeatureReadApiService : ApiReadService<ResultFeatureDto>, IFeatureReadApiService
    {
        public FeatureReadApiService(HttpClient client, IAuthorizationTokenApiService authorizationTokenApiService) : base(client, authorizationTokenApiService)
        {
        }
    }
}
