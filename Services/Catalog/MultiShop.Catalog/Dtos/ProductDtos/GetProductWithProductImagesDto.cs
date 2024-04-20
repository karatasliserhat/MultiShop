using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos
{
    public class GetProductWithProductImagesDto
    {
        public string ProductId { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
