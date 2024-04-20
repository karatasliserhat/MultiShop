using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class ProductImageCommandApiService : ApiCommandService<UpdateProductImageDto, CreateProductImageDto>, IProductImageCommandApiService
    {
        public ProductImageCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
