using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnotherMiddleware
    {
        private readonly RequestDelegate _next;

        public AnotherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await httpContext.Response.WriteAsync("\nAnotherMiddleware: started \n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("\nAnotherMiddleware: ended \n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnotherMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnotherMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherMiddleware>();
        }
    }
}
