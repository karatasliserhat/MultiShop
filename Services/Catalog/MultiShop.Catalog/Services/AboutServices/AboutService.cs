using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var connection = new MongoClient(_databaseSettings.ConnectionString);
            var database = connection.GetDatabase(_databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _aboutCollection.InsertOneAsync(_mapper.Map<About>(createAboutDto));
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            return _mapper.Map<List<ResultAboutDto>>(await _aboutCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            return _mapper.Map<GetByIdAboutDto>(await _aboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, _mapper.Map<About>(updateAboutDto));
        }
    }
}
