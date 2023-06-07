using System.Text.Json;
using src;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        var products = new List<string> { "product A", "product B" };

        //app.MapGet("/products", async (HttpContext context) =>
        //{
        //    var name = context.Request.Query["name"];
        //    Console.WriteLine(name);
        //    var product = products.Find(item => item == name);
        //    if (product == null)
        //    {
        //        context.Response.StatusCode = StatusCodes.Status404NotFound;
        //        await context.Response.WriteAsync("product not found");
        //    }
        //    else
        //        await context.Response.WriteAsync(product);
        //});

        app.MapGet("/products", async (HttpContext context, string name) =>
        {            
            Console.WriteLine(name);
            var product = products.Find(item => item == name);
            if (product == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("product not found");
            }
            else
                await context.Response.WriteAsync(product);
        });
        app.MapGet("/getProducts", async (HttpContext context) =>
        {
            context.Response.Headers["testing-header"] = products[0];
            await context.Response.WriteAsync(JsonSerializer.Serialize(products));
        });

        app.MapPost("/products", async (HttpContext context, Product product) =>
        {
            products.Add(product.name);

            //201 created
            //200 Ok
            context.Response.StatusCode = StatusCodes.Status201Created;
            await context.Response.WriteAsync("Product Created!");
        });

        //var firstMiddleware = new MiddleWare1();
        //var secondMiddleware = new MiddleWare2();

        //firstMiddleware.SetNext(secondMiddleware);
        //firstMiddleware.Handle();

        app.Run();
    }
}

record Product(string name);