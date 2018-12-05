using Manulife.DNC.MSAD.MassTransitv4.Messages;
using MassTransit;
using System;

namespace Manulife.DNC.MSAD.MassTransitTestv4.ObserverPublish
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Masstransit Observer Publisher";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });
            });

            var observer1 = new SendObserver();
            var handle1 = bus.ConnectSendObserver(observer1);

            var observer2 = new PublishObserver();
            var handle2 = bus.ConnectPublishObserver(observer2);

            bus.Start();

            do
            {
                Console.WriteLine("Presss q if you want to exit this program.");
                string message = Console.ReadLine();
                if (message.ToLower().Equals("q"))
                {
                    break;
                }

                bus.Publish(new TestMessage
                {
                    MessageId = 10001,
                    Content = message,
                    Time = DateTime.Now
                });
            } while (true);

            bus.Stop();
        }
    }
}
