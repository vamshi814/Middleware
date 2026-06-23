namespace Middleware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //before next middleware
            await context.Response.WriteAsync("MyMiddleware: started \n");
            await next(context); // Call the next middleware in the pipeline
            await context.Response.WriteAsync("MyMiddleware: ended \n");

        }
    }
}
