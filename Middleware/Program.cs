//creating an instance of the web application builder
var builder = WebApplication.CreateBuilder(args);

//create an instance of the web application(ASP.NET Core application)
var app = builder.Build();

//server knows how to handle incoming requests and send responses back to the client
//app.MapGet("/", () => "Hello World!");


//run the application and start listening for incoming requests

//our ASP.NET Core application will be hosted on a web server
//and will be able to handle incoming HTTP requests and send responses back to the client

//httpcontext is an object that represents the current HTTP request and response
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hosted on Server \n" +
        "httpcontext is an object that represents the current HTTP request and response");
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Next Middleware");
});

app.Run();//start the application and listen for incoming requests