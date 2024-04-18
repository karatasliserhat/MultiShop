using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandMongoCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var connection = new MongoClient(_databaseSettings.ConnectionString);
            var database = connection.GetDatabase(_databaseSettings.DatabaseName);
            _brandMongoCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _brandMongoCollection.InsertOneAsync(_mapper.Map<Brand>(createBrandDto));
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandMongoCollection.DeleteOneAsync(x => x.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            return _mapper.Map<List<ResultBrandDto>>(await _brandMongoCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            return _mapper.Map<GetByIdBrandDto>(await _brandMongoCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _brandMongoCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, _mapper.Map<Brand>(updateBrandDto));
        }

      
    }
}
