using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class FeatureSliderReadApiService : ApiReadService<ResultFeatureSliderDto>, IFeatureSliderReadApiService
    {
        public FeatureSliderReadApiService(HttpClient client) : base(client)
        {
        }
    }
}
