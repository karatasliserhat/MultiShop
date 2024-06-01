using MultiShop.DtoLayer.CommentDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class CommentReadApiService : ApiReadService<ResultCommentDto>, ICommentReadApiService
    {
        private readonly HttpClient _client;
        public CommentReadApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<int> GetActiveCommentCount()
        {
            return await _client.GetFromJsonAsync<int>("Comments/GetActiveCommentCount");
        }

        public async Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string productId)
        {
            return await _client.GetFromJsonAsync<List<ResultCommentDto>>($"Comments/GetCommentByProductId/{productId}");
        }

        public async Task<int> GetPassiveCommentCount()
        {
            return await _client.GetFromJsonAsync<int>("Comments/GetPassiveCommentCount");
        }

        public async Task<int> GetTotalCommentCount()
        {
            return await _client.GetFromJsonAsync<int>("Comments/GetTotalCommentCount");

        }
    }
}
