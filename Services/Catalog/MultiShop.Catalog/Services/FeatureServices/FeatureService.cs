using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var connect = new MongoClient(_databaseSettings.ConnectionString);
            var database = connect.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _featureCollection.InsertOneAsync(_mapper.Map<Feature>(createFeatureDto));
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            return _mapper.Map<List<ResultFeatureDto>>(await _featureCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            return _mapper.Map<GetByIdFeatureDto>(await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, _mapper.Map<Feature>(updateFeatureDto));
        }
    }
}
