namespace MultiShop.Shared.Settings
{
    public interface IApiSettings
    {
        public string CatalogApiUrl { get; set; }
        public string DiscountApiUrl { get; set; }
        public string CommentApiUrl { get; set; }
        public string IdentityApiUrl { get; set; }
    }
}
