﻿namespace MultiShop.Cargo.EntityLayer.Concreate
{
    public class CargoCustomer
    {
        public int CargoCustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
        public virtual List<CargoDetail> CargoDetails { get; set; }
    }
}
