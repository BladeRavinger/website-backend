using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using UKSFWebsite.api.Core.Authentication;

namespace UKSFWebsite.api.Core.Middleware
{
    public class ApiAuthenticationHandler : AuthenticationHandler<ApiAuthenticationOptions>, IApiKeyValidator
    {
        private IApiKeyValidator validator;

        public ApiAuthenticationHandler(IApiKeyValidator validator)
        {
            this.validator = validator;
        }

        public async Task<bool> ValidateAsync(string apiKey)
        {
            Console.WriteLine("validateasync");
            return await HandleRequestAsync();
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Console.WriteLine("loggin in");
            LoginAttempt attempt = new LoginAttempt(Context);
            return await attempt.TryLogin();
        }
    }
}
