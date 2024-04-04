using MultiShop.Catalog.Dtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    }
}
