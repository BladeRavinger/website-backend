using Microsoft.AspNetCore.Http;
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

        public Task Invoke(HttpContext context)
        {
            return this.next(context);
        }
    }
}
