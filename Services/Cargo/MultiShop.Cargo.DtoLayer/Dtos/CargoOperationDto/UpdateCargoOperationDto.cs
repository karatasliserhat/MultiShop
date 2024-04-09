namespace MultiShop.Cargo.DtoLayer.Dtos
{
    public class UpdateCargoOperationDto
    {
        public int CargoOperationId { get; set; }
        public int Barcode { get; set; }
        public string Description { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
