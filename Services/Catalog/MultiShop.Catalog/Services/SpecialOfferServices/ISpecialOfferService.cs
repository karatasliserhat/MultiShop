using MultiShop.Catalog.Dtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
        Task CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    }
}
