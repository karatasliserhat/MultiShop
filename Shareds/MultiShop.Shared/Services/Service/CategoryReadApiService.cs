using MultiShop.Shared.Services.Abstract;
using MultiShop.DtoLayer.CatalogDtos;


namespace MultiShop.Shared.Services.Service
{
    public class CategoryReadApiService : ApiReadService<ResultCategoryDto>, ICategoryReadApiService
    {
        public CategoryReadApiService(HttpClient client, IAuthorizationTokenApiService authorizationTokenApiService) : base(client, authorizationTokenApiService)
        {
        }
    }
}
