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

        public async Task<AuthenticateResult> TryLogin()
        {
            Console.WriteLine("Logging in code running");
            Console.WriteLine(context.Request.Headers["Authentication"].ToString());
            Console.WriteLine(AuthTokenController.acceptedname);
            if (context.Request.Headers["Authentication"].ToString() == AuthTokenController.acceptedname)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "barry", ClaimValueTypes.String));

                var userIdentity = new ClaimsIdentity("SuperSecureLogin");
                userIdentity.AddClaims(claims);

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await context.Authentication.SignInAsync("Cookie", userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });


                var ticket = new AuthenticationTicket(userPrincipal, null, "AutomaticC");
                return AuthenticateResult.Success(ticket);
            }
            else
            {
                await Task.Delay(0);
                Console.WriteLine("Invalid api key");
                return AuthenticateResult.Fail("Invalid API key.");
            }
        }
    }
}
