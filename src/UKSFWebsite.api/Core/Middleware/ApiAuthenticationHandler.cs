using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using UKSFWebsite.api.Core.Authentication;

namespace UKSFWebsite.api.Core.Middleware
{
    public class ApiAuthenticationHandler : AuthenticationHandler<ApiAuthenticationOptions>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Console.WriteLine("loggin in");
            LoginAttempt attempt = new LoginAttempt(Context);
            return await attempt.TryLogin();
        }
    }
}
