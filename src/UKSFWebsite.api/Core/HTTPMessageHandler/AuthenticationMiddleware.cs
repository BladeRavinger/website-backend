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
    public class AuthenticationMiddleware : DelegatingHandler
    {

        private readonly RequestDelegate nextMiddleware;

        private bool authenticate(HttpContext context)
        {
            //this is where authenticatation of requests takes place. 
            //HttpContext.Authentication.

            return false;
        }

        public AuthenticationMiddleware(RequestDelegate nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (!context.Request.Headers.Keys.Contains("X-Not-Authorized"))
            if (!authenticate(context))
            {
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }

            await nextMiddleware.Invoke(context);
        }
    }
}