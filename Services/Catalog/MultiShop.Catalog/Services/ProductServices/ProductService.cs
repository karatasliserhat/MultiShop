using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);

            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            return _mapper.Map<List<ResultProductDto>>(await _productCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
        {
            return _mapper.Map<GetByIdProductDto>(await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync());
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstOrDefault();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryId(string categoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<ProductsWithCategoryWithImagesWithDetailDto> GetProductWithCategoryWithImagesWithDetailByProductIdAsync(string productId)
        {
            var product = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            product.Category = await _categoryCollection.Find(x => x.CategoryId == product.CategoryId).FirstOrDefaultAsync();

            product.ProductImages = await _productImageCollection.Find(x => x.ProductId == product.ProductId).ToListAsync();
            product.ProductDetail = await _productDetailCollection.Find(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();

            return _mapper.Map<ProductsWithCategoryWithImagesWithDetailDto>(product);
        }

        public async Task<GetProductWithProductDetailDto> GetProductWithWithDetailByProductIdAsync(string productId)
        {
            var product = await _productCollection.Find(x=> x.ProductId==productId).FirstOrDefaultAsync();
            product.ProductDetail=await _productDetailCollection.Find(x=> x.ProductId==product.ProductId).FirstOrDefaultAsync();

            return _mapper.Map<GetProductWithProductDetailDto>(product);
        }

        public async Task<GetProductWithProductImagesDto> GetProductWithWithImagesByProductIdAsync(string productId)
        {
            var product = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            product.ProductImages = await _productImageCollection.Find(x => x.ProductId == product.ProductId).ToListAsync();

            return _mapper.Map<GetProductWithProductImagesDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, _mapper.Map<Product>(updateProductDto));
        }

    }
}
