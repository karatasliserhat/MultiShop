namespace MultiShop.Shared.Settings
{
    public interface IApiSettings
    {
        public string CatalogApiUrl { get; set; }
        public string DiscountApiUrl { get; set; }
        public string CommentApiUrl { get; set; }
        public string OrderApiUrl { get; set; }
        public string CargoApiUrl { get; set; }
        public string BasketApiUrl { get; set; }
        public string PaymentApiUrl { get; set; }
        public string ImageApiUrl { get; set; }
        public string IdentityApiUrl { get; set; }
    }
}
