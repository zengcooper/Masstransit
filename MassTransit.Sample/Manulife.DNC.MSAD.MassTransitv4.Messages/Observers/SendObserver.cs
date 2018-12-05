using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitv4.Messages
{
    public class SendObserver : ISendObserver
    {
        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            Console.WriteLine("------------------PreSend--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("-------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            Console.WriteLine("------------------PostSend-------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("-------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine("------------------SendFault-----------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("-------------------------------------------------");

            return Task.CompletedTask;
        }
    }
}
