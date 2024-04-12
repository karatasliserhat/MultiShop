using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IProductCommandApiService : IApiCommandService<UpdateProductDto, CreateProductDto>
    {
    }
}
