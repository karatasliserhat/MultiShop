using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class FeatureSliderCommandApiService : ApiCommandService<UpdateFeatureSliderDto, CreateFeatureSliderDto>, IFeatureSliderCommandApiService
    {
        public FeatureSliderCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
