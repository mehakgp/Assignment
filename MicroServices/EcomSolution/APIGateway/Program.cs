using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Services.AddOcelot();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.UseRouting();
            app.UseOcelot().Wait();

            app.MapControllers();
            app.Run();
        }
    }
}
