namespace MultiShop.Cargo.EntityLayer.Concreate
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
        public virtual CargoCompany CargoCompany { get; set; }

    }
}
