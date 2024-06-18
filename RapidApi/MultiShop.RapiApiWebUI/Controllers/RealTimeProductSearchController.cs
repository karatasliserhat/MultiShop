using Microsoft.AspNetCore.Mvc;
using MultiShop.RapiApiWebUI.Models;
using MultiShop.RapiApiWebUI.Settings;
using Newtonsoft.Json;

namespace MultiShop.RapiApiWebUI.Controllers
{
    public class RealTimeProductSearchController : Controller
    {
        private readonly IRapidApiSettings _settings;

        public RealTimeProductSearchController(IRapidApiSettings settings)
        {
            _settings = settings;
        }

        public IActionResult Index()
        {
            return View(new List<ProductSearchViewModel.Datum>());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchProduct)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={searchProduct}&country=tr&language=tr&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
    {
        { "x-rapidapi-key", _settings.XRapidApiKey },
        { "x-rapidapi-host", _settings.ProductSearch.XRapidApiHost },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductSearchViewModel>(body);
                return View(values.data.ToList());
            }
        }
    }
}
