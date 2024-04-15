using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferClient;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var connnect = new MongoClient(_databaseSettings.ConnectionString);
            var database = connnect.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferClient = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferClient.InsertOneAsync(_mapper.Map<SpecialOffer>(createSpecialOfferDto));
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferClient.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            return _mapper.Map<List<ResultSpecialOfferDto>>(await _specialOfferClient.Find(x =>  true).ToListAsync());
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            return _mapper.Map<GetByIdSpecialOfferDto>(await _specialOfferClient.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferClient.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, _mapper.Map<SpecialOffer>(updateSpecialOfferDto));
        }
    }
}
