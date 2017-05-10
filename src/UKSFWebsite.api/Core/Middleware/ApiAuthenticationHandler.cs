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
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Console.WriteLine("HandleAuthenticateAsync -- when does this occur");
            LoginAttempt attempt = new LoginAttempt(Context);
            return await attempt.TryLogin();
        }

        public override async Task<bool> HandleRequestAsync()
        {
            Console.WriteLine("Authorizing with UKSF Authentication System");
            LoginAttempt attempt = new LoginAttempt(Context);
            return await attempt.TryLogin() == null;
        }

        protected override Task HandleSignInAsync(SignInContext context)
        {
            Console.WriteLine("Sign in async called -- when does this occur");
            return base.HandleSignInAsync(context);
        }
        
    }
}
