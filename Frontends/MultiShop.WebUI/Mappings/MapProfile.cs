using AutoMapper;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Mappings
{
    public class MapProfile : Profile
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

            CreateMap<ResultProductDetailDtos, GetProductDetailWithProductDto>();

            CreateMap<ResultProductDetailDtos, UpdateProductDetailDto>();

            CreateMap<ResultCommentDto, UpdateCommentDto>();
            CreateMap<ResultContactDto, UpdateContactDto>();

            CreateMap<ResultProductDto, BasketItemDto>().ForMember(x => x.ProductId, x => x.MapFrom(x => x.ProductId))
                .ForMember(x => x.ProductName, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.Price, x => x.MapFrom(x => x.Price))
                .ForMember(x => x.ProductImageUrl, x => x.MapFrom(x => x.ImageUrl)).ReverseMap();

            CreateMap<BasketTotalDto, BasketDiscountCalculateDto>().ReverseMap();
        }
    }
}
