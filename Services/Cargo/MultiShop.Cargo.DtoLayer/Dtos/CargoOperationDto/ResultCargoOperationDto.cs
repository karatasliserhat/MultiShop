namespace MultiShop.Cargo.DtoLayer.Dtos
{
    public class ResultCargoOperationDto
    {
        public int CargoOperationId { get; set; }
        public int Barcode { get; set; }
        public string Description { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
