using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class ProductDetailCommandApiService : ApiCommandService<UpdateProductDetailDto, CreateProductDetailDto>, IProductDetailCommandApiService
    {
        public ProductDetailCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}
