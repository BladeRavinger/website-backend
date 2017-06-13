using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Middleware
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            context.Response.OnStarting(() =>
            {
                stopwatch.Stop();
                context.Response.Headers["ResponseTime"] = stopwatch.ElapsedMilliseconds.ToString();
                return Task.CompletedTask;
            });
            await next(context);
            stopwatch.Stop();
        }
    }
    public static class ResponseTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseTime(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseTimeMiddleware>();
        }
    }
}
