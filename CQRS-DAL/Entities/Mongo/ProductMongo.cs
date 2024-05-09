using MongoDB.Bson;

namespace CQRS_DAL.Entities.Mongo
{
    public class ProductMongo
    {
        public ObjectId Id { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
