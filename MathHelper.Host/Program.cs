using System;
using Nancy.Hosting.Self;

namespace MathHelper.Host
{
    static class Program
    {
        static void Main(string[] args)
        {
            var hostConfigs = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = false }
            };

            var uri = new Uri("http://localhost:1234");
            var host = new NancyHost(hostConfigs, uri);
            host.Start();
            Console.WriteLine("Service started");
            Console.ReadLine();
            host.Stop();
        }
    }
}