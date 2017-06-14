using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Middleware
{
    public class RequestStatusMiddleware
    {
        private readonly RequestDelegate next;

        public RequestStatusMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Request-Description", "The request was received but processed no further.");
            context.Response.Headers.Add("Request-Status", "Received");
            await next(context);
        }
    }
    public static class RequestStatusMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestStatus(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestStatusMiddleware>();
        }
    }
}
