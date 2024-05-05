using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class BasketCommandApiService : IBasketCommandApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IBasketReadApiService _basketReadApiService;

        public BasketCommandApiService(HttpClient httpClient, IBasketReadApiService basketReadApiService)
        {
            _httpClient = httpClient;
            _basketReadApiService = basketReadApiService;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await _basketReadApiService.GetBasketAsync();
            if (values.BasketItems.Count>0)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {

                    basketItemDto.Quantity = 1;
                    values.BasketItems.Add(basketItemDto);
                    await SaveBasketAsync(values);
                }
                else
                {
                    values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId).Quantity += 1;
                    await SaveBasketAsync(values);

                }
            }
            else
            {
                basketItemDto.Quantity = 1;
                values.BasketItems.Add(basketItemDto);
                await SaveBasketAsync(values);
            }
            

        }

        public async Task<HttpResponseMessage> DeleteBasketAsync(string userId)
        {
            return await _httpClient.DeleteAsync($"Baskets/{userId}");
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await _basketReadApiService.GetBasketAsync();
            var basketItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            values.BasketItems.Remove(basketItem);
            await SaveBasketAsync(values);
            return true;

        }

        public async Task<HttpResponseMessage> SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            return await _httpClient.PostAsJsonAsync<BasketTotalDto>("Baskets", basketTotalDto);
        }
    }
}
