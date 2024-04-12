namespace MultiShop.DtoLayer.CatalogDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Descripiton { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
