namespace MultiShop.Cargo.DtoLayer.Dtos
{
    public class CreateCargoOperationDto
    {
        public int Barcode { get; set; }
        public string Description { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
