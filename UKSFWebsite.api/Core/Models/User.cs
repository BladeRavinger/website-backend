using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace UKSFWebsite.api.Core.Models
{
    public class User
    {
		[BsonId]
		public ObjectId id { get; set; } //MongoDb uses this field as identity.
		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public string username;
		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public string password;
		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public string email;
	}
}
