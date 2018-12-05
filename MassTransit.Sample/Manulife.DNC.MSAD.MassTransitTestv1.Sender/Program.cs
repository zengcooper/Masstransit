﻿using Manulife.DNC.MSAD.MassTransitTestv1.Receiver;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitTestv1.Sender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit Client";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });
            });

            var uri = new Uri("rabbitmq://192.168.80.71/EDCVHOST/Qka.MassTransitTest");
            var message = Console.ReadLine();

            while (message != null)
            {
                Task.Run(() => SendCommand(bus, uri, message)).Wait();
                message = Console.ReadLine();
            }

            Console.ReadKey();
        }

        private static async void SendCommand(IBusControl bus, Uri sendToUri, string message)
        {
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            var command = new Client()
            {
                Id = 100001,
                Name = "Edison Zhou",
                Birthdate = DateTime.Now.AddYears(-18),
                Message = message
            };

            await endPoint.Send(command);

            Console.WriteLine($"You Sended : Id = {command.Id}, Name = {command.Name}, Message = {command.Message}");
        }
    }
}
