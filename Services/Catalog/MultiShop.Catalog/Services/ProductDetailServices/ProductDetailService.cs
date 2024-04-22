using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailCollection.InsertOneAsync(_mapper.Map<ProductDetail>(createProductDetailDto));
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            return _mapper.Map<List<ResultProductDetailDto>>(await _productDetailCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            return _mapper.Map<GetByIdProductDetailDto>(await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync());
        }

        public async Task<GetProductDetailWithProductDto> GetProductDetailByProductIdAsync(string productId)
        {
            return _mapper.Map<GetProductDetailWithProductDto>(await _productDetailCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync());
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, _mapper.Map<ProductDetail>(updateProductDetailDto));
        }
    }
}
