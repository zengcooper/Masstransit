using MassTransit;
using System;

namespace Manulife.DNC.MSAD.MassTransitTestv2.SubscriberB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit SubscriberB";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv2.CB", e =>
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
