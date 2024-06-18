using Microsoft.AspNetCore.Mvc;
using MultiShop.RapiApiWebUI.Models;
using MultiShop.RapiApiWebUI.Settings;
using Newtonsoft.Json;

namespace MultiShop.RapiApiWebUI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IRapidApiSettings _raidApiSettings;

        public WeatherController(IRapidApiSettings raidApiSettings)
        {
            _raidApiSettings = raidApiSettings;
        }

        public async Task<IActionResult> WeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_raidApiSettings.WeatherApi.Uri),
                Headers =
    {
        { "x-rapidapi-key", _raidApiSettings.XRapidApiKey},
        { "x-rapidapi-host", _raidApiSettings.WeatherApi.XRapidApiHost},
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                return View(values);
            }
        }
    }
}
