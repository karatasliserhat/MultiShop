using System.Net.Http.Json;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class ApiCommandService<UpdateDto, CreateDto> : IApiCommandService<UpdateDto, CreateDto>
        where UpdateDto : class
        where CreateDto : class
    {
        private readonly HttpClient _client;

        public ApiCommandService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> CreateAsync(string controllername, CreateDto createDto)
        {
            var response = await _client.PostAsJsonAsync(controllername, createDto);
            return response;
        }
        public async Task<HttpResponseMessage> RemoveAsync(string controllerName, int id)
        {
            return await _client.DeleteAsync($"{controllerName}/{id}");
        }
        public async Task<HttpResponseMessage> RemoveAsync(string controllerName, string id)
        {
            return await _client.DeleteAsync($"{controllerName}/{id}");
        }

        public async Task<HttpResponseMessage> UpdateAsync(string controllerName, UpdateDto updateDto)
        {
            return await _client.PutAsJsonAsync(controllerName, updateDto);

        }
    }
}
