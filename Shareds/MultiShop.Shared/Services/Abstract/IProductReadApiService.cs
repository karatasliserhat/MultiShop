using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IProductReadApiService:IApiReadService<ResultProductDto>
    {
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryDto>> ProductListWithCategoryByCategoryId(string categoryId);
        Task<ResultProductWithCategoryWithImagesWithDetailDto> GetResultProductWithCategoryWithImagesWithDetailByProductIdAsync(string productId);
        Task<GetProductWithProductDetailDto> GetResultProductWithDetailByProductIdAsync(string productId);
        Task<GetProductWithProductImagesDto> GetResultProductWithImagesByProductIdAsync(string productId);
    }
}
