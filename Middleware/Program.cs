//importing Custom Middle ware
using Middleware.CustomMiddleware;

//creating an instance of the web application builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();

//create an instance of the web application(ASP.NET Core application)
var app = builder.Build();

//server knows how to handle incoming requests and send responses back to the client
//app.MapGet("/", () => "Hello World!");


//run the application and start listening for incoming requests

//our ASP.NET Core application will be hosted on a web server
//and will be able to handle incoming HTTP requests and send responses back to the client

//httpcontext is an object that represents the current HTTP request and response
//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("1st middleware \n Hosted on Server " +
        "httpcontext is an object that represents the current HTTP request and response\n");
    await next(context); // updated context object is passed to the next middleware in the pipeline
});

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n2nd middleware started\n");
    await next(context); // updated context object is passed to the next middleware in the pipeline
    await context.Response.WriteAsync("\n2nd middleware ended\n");
});

//Middleware 3 
//Calling Custom Middleware
//app.UseMiddleware<MyMiddleware>(); instead we can use extension method
//app.UseMyMiddleware();
app.UseAnotherMiddleware();

//Middleware 4
app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized")
                        && context.Request.Query["IsAuthorized"] == "true",
    appBuilder =>
    {
        appBuilder.Use(async (HttpContext context, RequestDelegate next) =>
        {
            await context.Response.WriteAsync("\n4th middleware started\n");
            await next(context); // updated context object is passed to the next middleware in the pipeline
            await context.Response.WriteAsync("\n4th middleware ended\n");
        });
    });


//Middleware 5
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\n5th middleware\n");
});

app.Run();//start the application and listen for incoming requests