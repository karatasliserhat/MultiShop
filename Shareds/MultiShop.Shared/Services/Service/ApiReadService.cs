using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class ApiReadService<ResultDto> : IApiReadService<ResultDto> where ResultDto : class
    {
        private readonly HttpClient _client;
        public ApiReadService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ResultDto> GetByIdAsync(string controllerName, int id)
        {
            return await _client.GetFromJsonAsync<ResultDto>($"{controllerName}/{id}");

        }
        public async Task<ResultDto> GetByIdAsync(string controllerName, string id)
        {
            return await _client.GetFromJsonAsync<ResultDto>($"{controllerName}/{id}");

        }
        public async Task<List<ResultDto>> GetListAsync(string controllerName)
        {
            return await _client.GetFromJsonAsync<List<ResultDto>>(controllerName);
        }
        public async Task<List<ResultDto>> GetListAsync(string controllerName, string actionName)
        {
            return await _client.GetFromJsonAsync<List<ResultDto>>($"{controllerName}/{actionName}");
        }
    }
}
