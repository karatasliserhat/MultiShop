﻿namespace MultiShop.DtoLayer.CargoDtos
{
    public class GetCargoCustomerWithUserIdDto
    {
        public int CargoCustomerId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
    }
}