namespace MultiShop.DtoLayer.CatalogDtos
{
    public class GetProductWithProductImagesDto
    {
        public string ProductId { get; set; }
        public List<ResultProductImagesDto> ProductImages { get; set; }
    }
}
