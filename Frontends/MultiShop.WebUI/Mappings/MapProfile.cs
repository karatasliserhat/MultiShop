using AutoMapper;
using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.WebUI.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ResultCategoryDto, UpdateCategoryDto>();
            CreateMap<ResultProductDto, UpdateProductDto>();
            CreateMap<ResultFeatureSliderDto, UpdateFeatureSliderDto>();
            CreateMap<ResultSpecialOfferDto, UpdateSpecialOfferDto>();
            CreateMap<ResultFeatureDto, UpdateFeatureDto>();
            CreateMap<ResultOfferDiscountDto, UpdateOfferDiscountDto>();
            CreateMap<ResultBrandDto, UpdateBrandDto>();
            CreateMap<ResultAboutDto, UpdateAboutDto>();
            CreateMap<ResultProductImagesDto, UpdateProductImageDto>();
        }
    }
}
