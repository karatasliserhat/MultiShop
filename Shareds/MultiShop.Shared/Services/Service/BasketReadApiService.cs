using Microsoft.AspNetCore.Http;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class BasketReadApiService : IBasketReadApiService
    {
        private readonly HttpClient _httpClient;

        public BasketReadApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<BasketTotalDto>("Baskets");

            return values;
        }
    }
}
