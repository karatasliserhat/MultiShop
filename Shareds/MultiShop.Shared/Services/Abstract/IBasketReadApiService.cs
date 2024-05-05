using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IBasketReadApiService
    {
        Task<BasketTotalDto> GetBasketAsync();
    }
}
