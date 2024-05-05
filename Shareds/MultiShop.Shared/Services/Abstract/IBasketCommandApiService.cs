using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IBasketCommandApiService
    {
        Task<HttpResponseMessage> SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string ProductId);
        Task<HttpResponseMessage> DeleteBasketAsync(string userId);
    }
}
