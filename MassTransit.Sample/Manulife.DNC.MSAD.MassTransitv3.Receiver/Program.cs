using MassTransit;
using System;

namespace Manulife.DNC.MSAD.MassTransitv3.Receiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit Response Side";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv3", e =>
                {
                    e.Consumer<RequestConsumer>();
                });
            });

            bus.Start();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
