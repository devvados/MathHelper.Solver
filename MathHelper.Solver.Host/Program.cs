using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MathHelper.Solver.Host
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:8080")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}