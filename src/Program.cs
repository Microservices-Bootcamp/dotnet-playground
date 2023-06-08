using System.Text.Json;
using src;
using src.Middlewares;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddTransient<FirstMiddleware>();
        builder.Services.AddControllers();
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

        //app.MapGet("/products/{name}", async (HttpContext context, string name) =>
        //{
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
        app.MapGet("/getProducts", async (HttpContext context) =>
        {
            //context.Response.Headers["testing-header"] = products[0];
            await context.Response.WriteAsync(JsonSerializer.Serialize(products));
        });

        //app.MapPost("/products", async (HttpContext context, Product product) =>
        //{
        //    products.Add(product.name);

        //    //201 created
        //    //200 Ok
        //    context.Response.StatusCode = StatusCodes.Status201Created;
        //    await context.Response.WriteAsync("Product Created!");
        //});

        app.MapGet("/files/{fileName}.{extension}", async (HttpContext context, string fileName, string extension) =>
        {
            await context.Response.WriteAsync($"file name: {fileName} with Extension: {extension} has been requested");
        });

        app.MapGet("/v2/files/{fileName=solidDefault}", async (HttpContext context, string fileName) =>
        {
            await context.Response.WriteAsync($"file name: {fileName}");
        });
        //var firstMiddleware = new MiddleWare1();
        //var secondMiddleware = new MiddleWare2();

        //firstMiddleware.SetNext(secondMiddleware);
        //firstMiddleware.Handle();
        //app.UseMiddleware<FirstMiddleware>();
        //app.UseFirstMiddlware();       
        app.UseStaticFiles();
        app.MapControllers();
        app.Run();
    }
}

//record Product(string name);