using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureCollection;
        private readonly IMapper _mapper;
        public FeatureSliderService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var connect = new MongoClient(_databaseSettings.ConnectionString);
            var database = connect.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureCollection.InsertOneAsync(_mapper.Map<FeatureSlider>(createFeatureSliderDto));
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            return _mapper.Map<List<ResultFeatureSliderDto>>(await _featureCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            return _mapper.Map<GetByIdFeatureSliderDto>(await _featureCollection.Find(x => x.FeatureSliderId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, _mapper.Map<FeatureSlider>(updateFeatureSliderDto));
        }
    }
}
