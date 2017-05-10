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
            IOptions<ApiAuthenticationOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {

        }

        protected override AuthenticationHandler<ApiAuthenticationOptions> CreateHandler()
        {
            return new ApiAuthenticationHandler();
        }
    }
    public class ApiAuthenticationOptions : AuthenticationOptions
    {
        public const string DefaultHeaderName = "Authorization";
        public string HeaderName { get; set; } = DefaultHeaderName;
    }
}