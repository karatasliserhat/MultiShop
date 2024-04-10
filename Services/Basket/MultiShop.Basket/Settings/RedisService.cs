using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _redisConnect;
        
        public RedisService(string url)
        {
            _redisConnect=ConnectionMultiplexer.Connect(url);
        }

        public IDatabase GetDb(int dbIndex)
        {
            return _redisConnect.GetDatabase(dbIndex);
        }

        
    }
}
