using MassTransit;
using System;

namespace Manulife.DNC.MSAD.MassTransitTestv2.SubscriberA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit SubscriberA";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv2.CA", e =>
                {
                    e.Consumer<ConsumerA>();
                });
            });

            bus.Start();
            Console.ReadKey(); // press Enter to Stop
            bus.Stop();
        }
    }
}
