namespace MultiShop.RapiApiWebUI.Settings
{
    public class RapidApiSettings : IRapidApiSettings
    {
        public ApiClient WeatherApi { get; set; }
        public ApiClient CurrencyExchange { get; set; }
        public ApiClient ProductSearch { get; set; }
        public string XRapidApiKey { get; set; }

    }
}
