using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitv4.Messages
{
    public class PublishObserver : IPublishObserver
    {
        public Task PrePublish<T>(PublishContext<T> context) where T : class
        {
            Console.WriteLine("------------------PrePublish--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("----------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostPublish<T>(PublishContext<T> context) where T : class
        {
            Console.WriteLine("------------------PostPublish--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("----------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PublishFault<T>(PublishContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine("------------------PublishFault--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("------------------------------------------------------");

            return Task.CompletedTask;
        }
    }
}
