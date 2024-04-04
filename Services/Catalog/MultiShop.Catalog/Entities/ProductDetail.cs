using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }
        public string Descrpition { get; set; }
        public string Information { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
