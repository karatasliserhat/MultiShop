namespace MultiShop.DtoLayer.CatalogDtos
{
    public class BasketDiscountCalculateDto
    {
        const decimal tax = 10;
        const decimal percent = 100;
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice
        {
            get => BasketItems.Sum(x => x.Quantity * x.Price);
        }
        public decimal TaxAmount { get => (TotalPrice / percent) * tax; }
        public decimal AmountIncludingTax { get => TotalPrice + TaxAmount; }

        public decimal DiscountedAmaunt { get => AmountIncludingTax - (AmountIncludingTax / percent) * Convert.ToDecimal(DiscountRate); }
    }
}
