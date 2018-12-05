using Manulife.DNC.MSAD.MassTransitv4.Messages;
using MassTransit;
using System;

namespace Manulife.DNC.MSAD.MassTransitTestv4.ObserverReceive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Masstransit Observer Receiver";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv4", e =>
                {
                    e.Consumer<TestMessageConsumer>();
                });
            });

            var observer = new ReceiveObserver();
            var handle = bus.ConnectReceiveObserver(observer);

            bus.Start();
            Console.ReadKey();
            bus.Stop();
        }
    }
}
