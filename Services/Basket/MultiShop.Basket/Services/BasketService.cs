using MultiShop.Basket.Dtos;
using StackExchange.Redis;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {

        private readonly IDatabase _redisDatabase;
        public BasketService(IDatabase redisDatabase)
        {
            _redisDatabase = redisDatabase;
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _redisDatabase.KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            var exitsBasket = await _redisDatabase.StringGetAsync(userId);
            if (!exitsBasket.IsNullOrEmpty)
            {
                return JsonSerializer.Deserialize<BasketTotalDto>(exitsBasket);

            }
            return null;
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisDatabase.StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
