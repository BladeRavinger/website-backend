using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UKSFWebsite.api.Middleware
{
    public class ComputeTimeMiddleware
    {
        private readonly RequestDelegate next;

        public ComputeTimeMiddleware(RequestDelegate next)
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
                context.Response.Headers["Compute-Time"] = stopwatch.ElapsedMilliseconds.ToString();
                return Task.CompletedTask;
            });
            await next(context);
            stopwatch.Stop();
        }
    }
    public static class ComputeTimeExtensions
    {
        public static IApplicationBuilder UseComputeTime(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ComputeTimeMiddleware>();
        }
    }
}
