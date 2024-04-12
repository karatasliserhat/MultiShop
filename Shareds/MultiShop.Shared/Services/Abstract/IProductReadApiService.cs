using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IProductReadApiService:IApiReadService<ResultProductDto>
    {
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
    }
}
