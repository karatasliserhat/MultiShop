using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<Product> _productCollection;
        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _productImageCollection.InsertOneAsync(_mapper.Map<ProductImage>(createProductImageDto));
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            return _mapper.Map<List<ResultProductImageDto>>(await _productImageCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            return _mapper.Map<GetByIdProductImageDto>(await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, _mapper.Map<ProductImage>(updateProductImageDto));
        }

        public async Task<List<GetImagesWithProductDto>> GetImagesWithProductByProductIdAsync(string productId)
        {
            var images = await _productImageCollection.Find(x => x.ProductId == productId).ToListAsync();
            foreach (var item in images)
            {
                item.Product = await _productCollection.Find(x => x.ProductId == item.ProductId).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<GetImagesWithProductDto>>(images);
        }
    }
}
