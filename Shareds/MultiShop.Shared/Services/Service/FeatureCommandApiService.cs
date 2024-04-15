using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class FeatureCommandApiService : ApiCommandService<UpdateFeatureDto, CreateFeatureDto>, IFeatureCommandApiService
    {
        public FeatureCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
