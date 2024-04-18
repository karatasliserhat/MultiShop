using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class BrandCommandService : ApiCommandService<UpdateBrandDto, CreateBrandDto>, IBrandCommandApiService
    {
        public BrandCommandService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
