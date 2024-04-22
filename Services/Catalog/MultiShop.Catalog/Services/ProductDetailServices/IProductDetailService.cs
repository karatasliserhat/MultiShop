using MultiShop.Catalog.Dtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<GetProductDetailWithProductDto> GetProductDetailByProductIdAsync(string productId);
    }
}
