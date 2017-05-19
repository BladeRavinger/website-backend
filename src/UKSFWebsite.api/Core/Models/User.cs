using MongoDB.Bson.Serialization.Attributes;


namespace UKSFWebsite.api.Core.Models
{
    public class User
    {
		public object _id { get; set; } //MongoDb uses this field as identity.

		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public string username { get; set; }

		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public string password { get; set;}
    }
}
