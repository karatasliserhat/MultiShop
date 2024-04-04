using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(categoryDto));
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);

        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            return _mapper.Map<List<ResultCategoryDto>>(await _categoryCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            return _mapper.Map<GetByIdCategoryDto>(await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == categoryDto.CategoryId, _mapper.Map<Category>(categoryDto));
        }
    }
}
