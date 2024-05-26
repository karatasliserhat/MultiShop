using MultiShop.DtoLayer.CargoDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class CargoCustomerReadApiService : ICargoCustomerReadApiService
    {
        private readonly HttpClient _client;

        public CargoCustomerReadApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<GetCargoCustomerWithUserIdDto> GetCargoCustomerWithUserId(string userId)
        {

            return await _client.GetFromJsonAsync<GetCargoCustomerWithUserIdDto>($"CargoCustomers/GetCargoCustomerWithUserId/{userId}");


        }
    }
}
