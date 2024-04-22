using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IProductDetailReadApiService : IApiReadService<ResultProductDetailDtos>
    {
        Task<GetProductDetailWithProductDto> GetProductDetailByProductIdAsync(string productId);
    }
}
