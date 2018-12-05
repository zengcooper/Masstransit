using Manulife.DNC.MSAD.MassTransitTestv2.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitTestv2.SubscriberB
{
    public class ConsumerA : IConsumer<TestCustomMessage>
    {
        public async Task Consume(ConsumeContext<TestCustomMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"SubscriberB => ConsumerA received message : {context.Message.Name}, {context.Message.Time}, {context.Message.Message}, Age: {context.Message.Age}, Type:{context.Message.GetType()}");
            Console.ResetColor();
        }
    }
}
