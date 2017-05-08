using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UKSFWebsite.api.Core.HTTPMessageHandler
{
    public class AuthenticationMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Process request");
            authenticate();

            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("Process response");

            return response;
        }

        private void authenticate()
        {
            //this is where authenticatation of requests takes place. 
            //HttpContext.Authentication.
        }

        private readonly RequestDelegate _next;

        public AuthenticationMessageHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //need to use context.Authentication.
            if (!context.Request.Headers.Keys.Contains("X-Not-Authorized"))
            {
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }

            await _next.Invoke(context);
        }
    }
}