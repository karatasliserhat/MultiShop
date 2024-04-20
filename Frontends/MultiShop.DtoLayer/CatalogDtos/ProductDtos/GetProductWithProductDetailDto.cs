namespace MultiShop.DtoLayer.CatalogDtos
{
    public class GetProductWithProductDetailDto
    {
        public string ProductId { get; set; }
        public ResultProductDetailDtos ProductDetail { get; set; }
    }
}
