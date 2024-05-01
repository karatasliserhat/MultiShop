using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class BrandReadService : ApiReadService<ResultBrandDto>, IBrandReadApiService
    {
        public BrandReadService(HttpClient client) : base(client)
        {
        }
    }
}
