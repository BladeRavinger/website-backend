using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UKSFWebsite.api.Core.Models;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http;

namespace UKSFWebsite.api.Core.Registration
{
	public class Registration : IRegistration
	{
		private string username;
		private string password;
		private string email;
		private HttpContext httpContext;

		public Registration()
		{
			// Empty
		}

		public Registration(HttpContext httpContext)
		{
			this.httpContext = httpContext;
		}

		/// <summary>
		/// Triggers the registration process and redirects if checkUserExists returns true
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="email"></param>
		/// <returns>Null</returns>
		public async Task tryRegister()
		{
            string username = httpContext.Request.Headers["username"];
            string password = httpContext.Request.Headers["password"];
            string email = httpContext.Request.Headers["email"];

            if (!checkUserExists(username))
			{
				await Register(username,password,email);
			} else
			{
				// Redirect?
			}
		}
		/// <summary>
		///  Register method, checks if userExists returns false, if it does then register the username, if not then return user exists.
		/// </summary>
		private async Task Register(string username, string password, string email)
		{
				var collection = Database.Database.getDatabase().getMongoDatabase().GetCollection<BsonDocument>("accounts");
				var user = new BsonDocument
				{
					{ "username", username},
					{ "password", password},
					{ "email", email}
				};
				await collection.InsertOneAsync(user);
		}
		/// <summary>
		/// Checks if user exists, if it does then return true else false
		/// </summary>
		/// <param name="username"></param>
		/// <returns>Boolean</returns>
		private Boolean checkUserExists(string username)
		{
			var collection = Database.Database.getDatabase().getMongoDatabase().GetCollection<User>("accounts");
			var query = from account in collection.AsQueryable()
						where account.username == username
						select account;
			if (query.Any())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}