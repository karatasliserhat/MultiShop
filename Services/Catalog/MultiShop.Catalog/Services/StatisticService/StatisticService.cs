
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticService
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = db.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = db.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = db.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.Price);
            var projection = Builders<Product>.Projection.Include(x => x.Name).Exclude(x => x.ProductId);

            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("Name").AsString;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.Price);
            var projection = Builders<Product>.Projection.Include(x => x.Name).Exclude(x => x.ProductId);

            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("Name").AsString;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            var result = products.Average(x => x.Price);
            return result;
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
