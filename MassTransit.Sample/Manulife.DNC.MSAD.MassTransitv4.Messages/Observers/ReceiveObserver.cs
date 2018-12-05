using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitv4.Messages
{
    public class ReceiveObserver : IReceiveObserver
    {
        public Task PreReceive(ReceiveContext context)
        {
            Console.WriteLine("------------------PreReceive--------------------");
            Console.WriteLine(Encoding.Default.GetString(context.GetBody()));
            Console.WriteLine("--------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostReceive(ReceiveContext context)
        {
            Console.WriteLine("------------------PostReceive--------------------");
            Console.WriteLine(Encoding.Default.GetString(context.GetBody()));
            Console.WriteLine("------------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task ReceiveFault(ReceiveContext context, Exception exception)
        {
            Console.WriteLine("------------------ReceiveFault--------------------");
            Console.WriteLine(Encoding.Default.GetString(context.GetBody()));
            Console.WriteLine("-------------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType) where T : class
        {
            Console.WriteLine("------------------PostConsume--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("--------------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType, Exception exception) where T : class
        {
            Console.WriteLine("------------------ConsumeFault-------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("--------------------------------------------------------");

            return Task.CompletedTask;
        }
    }
}
