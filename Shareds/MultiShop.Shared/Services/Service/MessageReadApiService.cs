using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class MessageReadApiService : ApiReadService<ResultMessageDto>, IMessageReadApiService
    {
        private readonly HttpClient _client;
        public MessageReadApiService(HttpClient client):base(client)
        {
            _client = client;
        }

        public async Task<List<ResultSendboxMessageDto>> SendBoxMessageAsync(string UserId)
        {
            var result = await _client.GetFromJsonAsync<List<ResultSendboxMessageDto>>($"messages/GetSenderAllMessage/{UserId}");
            if (result is { Count: > 0 })
            {
                return result;
            }
            return null;
        }
        public async Task<List<ResultInboxMessageDto>> InBoxMessageAsync(string UserId)
        {
            var result = await _client.GetFromJsonAsync<List<ResultInboxMessageDto>>($"messages/GetReceiverAllMessage/{UserId}");
            if (result is { Count: > 0 })
            {
                return result;
            }
            return null;
        }
        public async Task IsReadMessage(int MessageId)
        {
            await _client.GetAsync($"messages/IsReadMessage/{MessageId}");

        }

        public async Task<int> GetMessageCount()
        {
            return await _client.GetFromJsonAsync<int>("Messages/GetMessageCount");
        }
    }
}
