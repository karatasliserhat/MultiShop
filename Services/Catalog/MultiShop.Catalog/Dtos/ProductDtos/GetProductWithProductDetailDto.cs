using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos
{
    public class GetProductWithProductDetailDto
    {
        public string ProductId { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
