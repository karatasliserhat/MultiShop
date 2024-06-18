using Microsoft.AspNetCore.Mvc;
using MultiShop.RapiApiWebUI.Models;
using MultiShop.RapiApiWebUI.Settings;
using Newtonsoft.Json;

namespace MultiShop.RapiApiWebUI.Controllers
{
    public class CurrencyExchangeController : Controller
    {
        private readonly IRapidApiSettings _rapidApiSettings;

        public CurrencyExchangeController(IRapidApiSettings rapidApiSettings)
        {
            _rapidApiSettings = rapidApiSettings;
        }
        public IActionResult CurrencyExchangeIndex()
        {
            return View(new CurrencyExchangeViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CurrencyExchangeIndex(string fromSymbol, string toSymbol)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol={fromSymbol}&language=TR&to_symbol={toSymbol}"),
                Headers =
    {
        { "x-rapidapi-key", _rapidApiSettings.XRapidApiKey },
        { "x-rapidapi-host", _rapidApiSettings.CurrencyExchange.XRapidApiHost },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CurrencyExchangeViewModel>(body);
                return View(values);

            }
        }
    }
}
