using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
    public class ProductType : BaseEntity
    {
        //[BsonElement("name")] to store with different name in MongoDB
        public string Name { get; set; }
    }
}
