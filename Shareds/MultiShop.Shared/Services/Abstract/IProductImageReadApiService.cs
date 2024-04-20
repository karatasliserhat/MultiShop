using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IProductImageReadApiService:IApiReadService<ResultProductImagesDto>
    {
        Task<List<GetImagesWithProductDto>> GetImagesWithProductByProductIdAsync(string productId);
    }
}
