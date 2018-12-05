using Manulife.DNC.MSAD.MassTransitTestv2.Messages;
using MassTransit;
using System;

namespace Manulife.DNC.MSAD.MassTransitTestv2.PublisherA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit Publisher";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST/"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });
            });

            do
            {
                Console.WriteLine("Please enter your message, if want to exit please press q.");
                string message = Console.ReadLine();
                if (message.ToLower().Equals("q"))
                {
                    break;
                }

                bus.Publish(new TestBaseMessage()
                {
                    Name = "Edison Zhou",
                    Time = DateTime.Now,
                    Message = message
                });

                bus.Publish(new TestCustomMessage()
                {
                    Name = "Leo Dai",
                    Age = 27,
                    Time = DateTime.Now,
                    Message = message
                });
            } while (true);

            bus.Stop();
        }
    }
}
