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

namespace UKSFWebsite.api.Core.Authentication
{
    public class LoginAttempt
    {
        private string userid;
        private string password;
        private HttpContext context;

        public bool success { get; private set; }
        public bool accountExists { get; private set; }

        public LoginAttempt(string userid, string password)
        {
            this.userid = userid;
            this.password = password;

        }

        public LoginAttempt(HttpContext context)
        {
            this.context = context;
        }

        public async Task TryLogin()
        {
            Console.WriteLine("Attempting to log in");

            if (context.Request.Headers["userid"].ToString() == "testing" && context.Request.Headers["password"].ToString() == "testing")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "JohnDoe", ClaimValueTypes.String));

                ClaimsIdentity userIdentity = new ClaimsIdentity("Name Identity");
                userIdentity.AddClaims(claims);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);

                await context.Authentication.SignInAsync("Cookie", userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });
                Console.WriteLine("Logged in successfully");
            }
            else
            {
                Console.WriteLine("Failed to log in");
            }
        }
        
    }
}
