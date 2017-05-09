using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace UKSFWebsite.api.Core.HTTPMessageHandler
{
    public class ApiAuthenticationHandler : AuthenticationHandler<ApiAuthenticationOptions>
    {
        public ApiAuthenticationHandler()
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {

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
