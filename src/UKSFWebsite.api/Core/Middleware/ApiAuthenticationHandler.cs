using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features.Authentication;
using UKSFWebsite.api.Core.Authentication;

namespace UKSFWebsite.api.Core.Middleware
{
    public class ApiAuthenticationHandler : AuthenticationHandler<ApiAuthenticationOptions>
    {
        private IApiKeyValidator validator;

        public ApiAuthenticationHandler(IApiKeyValidator validator)
        {
            this.validator = validator;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Console.WriteLine("loggin in");
            LoginAttempt attempt = new LoginAttempt(Context);
            return await attempt.TryLogin();
        }

        public override async Task<bool> HandleRequestAsync()
        {
            Console.WriteLine("auth request in");
            LoginAttempt attempt = new LoginAttempt(Context);
            return await attempt.TryLogin() != null;
        }

        protected override Task HandleSignInAsync(SignInContext context)
        {
            Console.WriteLine("auth sign in");
            return base.HandleSignInAsync(context);
        }
    }

    public class AuthHa: IApiKeyValidator
    {


        public async Task<bool> ValidateAsync(string apiKey)
        {
            Console.WriteLine("validateasync");
            return await Task.FromResult(true);
        }

    }
}
