namespace MultiShop.DtoLayer.OrderDtos
{
    public class CreateOrderingDto
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
