namespace MultiShop.Cargo.EntityLayer.Concreate
{
    public class CargoCompany
    {
        public int CargoCompanyId { get; set; }
        public string Name { get; set; }
        public virtual List<CargoDetail> CargoDetails { get; set; }
    }
}
