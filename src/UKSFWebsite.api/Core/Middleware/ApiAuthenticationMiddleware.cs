using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UKSFWebsite.api.Core.Middleware
{
    public class ApiAuthenticationMiddleware : AuthenticationMiddleware<ApiAuthenticationOptions>
    {
        public ApiAuthenticationMiddleware(
            RequestDelegate next,
            IApiKeyValidator validator,
            IOptions<ApiAuthenticationOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {
            Console.WriteLine("CreateHandler");
            this.validator = validator;
        }

        protected IApiKeyValidator validator;

        protected override AuthenticationHandler<ApiAuthenticationOptions> CreateHandler()
        {

            Console.WriteLine("CreateHandler");
            return new ApiAuthenticationHandler(validator);
        }
    }
    public class ApiAuthenticationOptions : AuthenticationOptions
    {
        public const string DefaultHeaderName = "Authorization";
        public string HeaderName { get; set; } = DefaultHeaderName;
    }
}