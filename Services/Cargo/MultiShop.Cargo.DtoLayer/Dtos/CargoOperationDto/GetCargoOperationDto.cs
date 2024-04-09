namespace MultiShop.Cargo.DtoLayer.Dtos
{
    public class GetCargoOperationDto
    {
        public int CargoOperationId { get; set; }
        public int Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
