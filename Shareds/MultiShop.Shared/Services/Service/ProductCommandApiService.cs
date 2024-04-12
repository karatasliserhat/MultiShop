using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class ProductCommandApiService : ApiCommandService<UpdateProductDto, CreateProductDto>, IProductCommandApiService
    {
        public ProductCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
