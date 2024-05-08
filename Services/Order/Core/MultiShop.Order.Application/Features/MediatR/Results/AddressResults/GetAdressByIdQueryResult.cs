﻿namespace MultiShop.Order.Application.Features.MediatR.Results
{
    public class GetAdressByIdQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
