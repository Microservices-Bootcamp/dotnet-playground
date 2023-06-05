internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        var products = new List<string> { "product A", "product B" };

        app.MapGet("/products", async (context) =>
        {
            var productId = context.Request.Form["PRODUCTID"];
            Console.WriteLine(productId);
            await context.Response.WriteAsync($"productId{productId}");
        });

        app.Run();
    }
}