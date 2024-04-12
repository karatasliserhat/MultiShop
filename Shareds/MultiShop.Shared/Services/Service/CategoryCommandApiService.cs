using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class CategoryCommandApiService : ApiCommandService<UpdateCategoryDto, CreateCategoryDto>, ICategoryCommandApiService
    {
        public CategoryCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
