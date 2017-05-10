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
namespace UKSFWebsite.api.Core.Authentication
{
    public class LoginAttempt
    {
        private string userid;
        private string password;
        private HttpContext request;

        public bool success { get; private set; }
        public bool accountExists { get; private set; }

        public LoginAttempt(string userid, string password)
        {
            this.userid = userid;
            this.password = password;

        }

        public LoginAttempt(HttpContext request)
        {
            this.request = request;
        }

        public async Task<AuthenticateResult> TryLogin()
        {
            Console.WriteLine("TryLogin");

            
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "barry", ClaimValueTypes.String));

            var userIdentity = new ClaimsIdentity("SuperSecureLogin");
            userIdentity.AddClaims(claims);

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await request.Authentication.SignInAsync("Bearer", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });


            var ticket = new AuthenticationTicket(userPrincipal, null, "AutomaticC");
            return AuthenticateResult.Success(ticket);

            /*StringValues headerValue;
            if (!Context.Headers.TryGetValue(Options.HeaderName, out headerValue))
            {
                return AuthenticateResult.Fail("Missing or malformed 'Authorization' header.");
            }

            var apiKey = headerValue.First();
            if (!_validator.ValidateAsync(apiKey))
            {
                return AuthenticateResult.Fail("Invalid API key.");
            }

            // success! Now we just need to create the auth ticket
            var identity = new ClaimsIdentity("apikey"); // the name of our auth scheme
            // you could add any custom claims here
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), null, "apikey");
            return AuthenticateResult.Success(ticket);*/
        }
    }
}
