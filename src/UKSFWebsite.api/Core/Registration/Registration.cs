using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UKSFWebsite.api.Core.Models;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace UKSFWebsite.api.Core.Registration
{
	public class Registration : IRegistration
	{
		private string username;
		private string password;
		private string email;
		public Registration(string username, string password, string email)
		{
			this.username = username;
			this.password = password;
			this.email = email;
		}
		/// <summary>
		///  Register method, checks if userExists returns false, if it does then register the username, if not then return user exists.
		/// </summary>
		public async Task register()
		{
			if(!userExists())
			{
				var collection = Database.Database.getDatabase().getMongoDatabase().GetCollection<BsonDocument>("accounts");
				var user = new BsonDocument
				{
					{ "username", username},
					{ "password", password},
					{ "email", email}
				};
				await collection.InsertOneAsync(user);
			} else
			{
			   // Redirect?
			}
		}

		public Boolean userExists()
		{
			var collection = Database.Database.getDatabase().getMongoDatabase().GetCollection<User>("accounts");
			var query = from account in collection.AsQueryable()
						where account.username == username
						select account;
			if (query.Any())
			{
				return true;
			} else
			{
				return false;
			}
		}
	}
}
