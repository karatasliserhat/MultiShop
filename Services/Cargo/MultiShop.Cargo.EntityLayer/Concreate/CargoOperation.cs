namespace MultiShop.Cargo.EntityLayer.Concreate
{
    public class CargoOperation
    {
        public int CargoOperationId { get; set; }
        public int Barcode { get; set; }
        public string Description { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
