﻿namespace MultiShop.DtoLayer.CatalogDtos
{
    public class UpdateSpecialOfferDto
    {
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
