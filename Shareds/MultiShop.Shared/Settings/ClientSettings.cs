namespace MultiShop.Shared.Settings
{
    public class ClientSettings : IClientSettings
    {
        public Client MultiShopVisitorClient { get; set; }
        public Client MultiShopManagerClient { get; set; }
        public Client MultiShopAdminClient { get; set; }
        public string DiscoveryUrl { get; set; }
        public string TokenUrl { get; set; }
    }
}
