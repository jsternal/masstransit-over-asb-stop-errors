using System;
using System.Configuration;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.AzureServiceBusTransport;

namespace MassTransitMinimal
{
    public class Program
    {
        private static readonly string AzureSbConn = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

        public static async Task Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(AzureSbConn, h => {});
            });

            bus.Start();
            bus.Stop();

            Console.WriteLine("Press any key to exit.");
            await Task.Run(Console.ReadKey);
        }
    }
}