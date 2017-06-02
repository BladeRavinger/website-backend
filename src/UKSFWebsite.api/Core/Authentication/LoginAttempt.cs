﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UKSFWebsite.api.Controllers;
using UKSFWebsite.api.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace UKSFWebsite.api.Core.Authentication
{
	public class LoginAttempt : ILoginAttempt
	{
		private string username;
		private string password;
		private HttpContext context;

		public bool success { get; private set; }
		public bool accountExists { get; private set; }

		public LoginAttempt(HttpContext context)
		{
			this.context = context;
		}

		public async Task TryLogin(string username, string password)
		{
			this.username = username;
			this.password = password;
			await attemptFindAccount();
		}

		/// <summary>
		///  Method below will attempt to find account through MongoDB, if successful it will trigger method applyLoginSuccess()
		/// </summary>
		/// <returns>Null</returns>
		private async Task attemptFindAccount()
		{
			var collection = Database.Database.getDatabase().getMongoDatabase().GetCollection<User>("accounts");
			var query = from account in collection.AsQueryable<User>()
						where account.username == username && account.password == password
						select account;
			if (query.Any())
			{
				applyLoginSuccess();
			}
			else
			{
			}
		}

		private async Task applyLoginSuccess()
		{
			ClaimsIdentity userIdentity = new ClaimsIdentity("Name Identity");

			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Name, "JohnDoe", ClaimValueTypes.String));
			claims.Add(new Claim(ClaimTypes.UserData, "Member", ClaimValueTypes.String));

			userIdentity.AddClaims(claims);

			ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);

			await context.Authentication.SignInAsync("Cookie", userPrincipal,
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
					IsPersistent = false,
					AllowRefresh = false
				}
			);
		}

	}
}
