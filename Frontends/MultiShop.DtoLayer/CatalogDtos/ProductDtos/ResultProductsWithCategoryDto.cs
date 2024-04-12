namespace MultiShop.DtoLayer.CatalogDtos
{
    public class ResultProductsWithCategoryDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Descripiton { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string DataProtect { get; set; }
    }
}
