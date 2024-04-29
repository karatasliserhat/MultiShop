using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class ApiReadService<ResultDto> : IApiReadService<ResultDto> where ResultDto : class
    {
        private readonly HttpClient _client;
        private readonly IAuthorizationTokenApiService _authorizationTokenApiService;
        public ApiReadService(HttpClient client, IAuthorizationTokenApiService authorizationTokenApiService)
        {
            _client = client;
            _authorizationTokenApiService = authorizationTokenApiService;
        }
        public async Task<ResultDto> GetByIdAsync(string controllerName, int id)
        {
            return await _client.GetFromJsonAsync<ResultDto>($"{controllerName}/{id}");

        }
        public async Task<ResultDto> GetByIdAsync(string controllerName, string id)
        {
            return await _client.GetFromJsonAsync<ResultDto>($"{controllerName}/{id}");

        }
        public async Task<List<ResultDto>> GetListAsync(string controllerName, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            return await _client.GetFromJsonAsync<List<ResultDto>>(controllerName);
        }
        public async Task<List<ResultDto>> GetListAsync(string controllerName, string actionName, string token)
        {
            
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _client.GetFromJsonAsync<List<ResultDto>>($"{controllerName}/{actionName}");
        }
    }
}
