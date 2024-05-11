namespace MultiShop.DtoLayer.OrderDtos
{
    public class GetOrderingByUserIdDto
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string DataProtect { get; set; }
        public string TableRowColor { get; set; }
    }
}

