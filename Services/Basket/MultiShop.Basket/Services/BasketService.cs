using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using StackExchange.Redis;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {

        private readonly IDatabase _redisDatabase;
        private readonly RedisService _redisService;
        public BasketService(IDatabase redisDatabase, RedisService redisService)
        {
            _redisDatabase = redisDatabase;
            _redisService = redisService;
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _redisDatabase.KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            var exitsBasket = await _redisDatabase.StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(exitsBasket);
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisDatabase.StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
