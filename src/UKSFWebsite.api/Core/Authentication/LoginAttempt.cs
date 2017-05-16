using System;
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
using MongoDB.Bson;
using MongoDB.Driver;

namespace UKSFWebsite.api.Core.Authentication
{
    public class LoginAttempt : ILoginAttempt
    {
        private string userid;
        private string password;
        private HttpContext context;

        public bool success { get; private set; }
        public bool accountExists { get; private set; }
        
        public LoginAttempt(HttpContext context)
        {
            this.context = context;
        }

        public async Task TryLogin(string userid, string password)
        {
            Console.WriteLine("Attempting to log in");

            this.userid = userid;
            this.password = password;

            await attemptFindAccount();

            if (userid == "testing" && password == "testing")
            {
                await applyLoginSuccess();
                Console.WriteLine("Logged in successfully");
            }
            else
            {
                Console.WriteLine("Failed to log in");
            }
        }

        private async Task attemptFindAccount()
        {
            //TODO
            //MongoDB find account here and do something with results
            var accounts = Database.Database.getDatabase().getMongoDatabase().GetCollection<BsonDocument>("accounts");
            var filter = Builders<BsonDocument>.Filter.Eq("userid", userid);
            await accounts.Find(filter).ForEachAsync(account => {
                if (account["password"] == password)
                    applyLoginSuccess();
            });
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
                new AuthenticationProperties{
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                }
            );
        }
        
    }
}
