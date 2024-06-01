using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IBrandReadApiService:IApiReadService<ResultBrandDto>
    {
        Task<int> GetBrandCount();
    }
}
