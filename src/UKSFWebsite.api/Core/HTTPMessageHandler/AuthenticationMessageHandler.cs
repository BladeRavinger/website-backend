using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Core.HTTPMessageHandler
{
    public class AuthenticationMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Debug.WriteLine("Process request");
            authenticate();

            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);

            //Debug.WriteLine("Process response");

            return response;
        }

        private void authenticate()
        {
            //this is where authenticatation of requests takes place. 
        }
    }
}