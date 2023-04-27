using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dao
{
    public class Restaurant
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        [BsonElement("restaurant_id")]
        public string RestaurantId { get; set; }
        public string Cuisine { get; set; }
        public Address Address { get; set; }
        public string Borough { get; set; }
        public List<GradeEntry> Grades { get; set; }
    }

    public class Address
    {
        public string Building { get; set; }
        [BsonElement("coord")]
        public float[] Coordinates { get; set; }
        public string Street { get; set; }
        [BsonElement("zipcode")]
        public string ZipCode { get; set; }
    }

    public class GradeEntry
    {
        public DateTime Date { get; set; }
        public string Grade { get; set; }
        public float Score { get; set; }
    }    
}

