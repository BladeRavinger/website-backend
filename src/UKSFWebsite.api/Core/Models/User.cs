using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace UKSFWebsite.api.Core.Models
{
    public class User
    {
		public ObjectId id { get; set; } //MongoDb uses this field as identity.

        public string username;
        public string password;
    }
}
