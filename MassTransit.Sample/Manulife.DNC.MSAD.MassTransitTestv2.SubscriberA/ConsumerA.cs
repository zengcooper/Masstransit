using Manulife.DNC.MSAD.MassTransitTestv2.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitTestv2.SubscriberA
{
    public class ConsumerA : IConsumer<TestBaseMessage>
    {
        public async Task Consume(ConsumeContext<TestBaseMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"SubscriberA => ConsumerA received message : {context.Message.Name}, {context.Message.Time}, {context.Message.Message}, Type:{context.Message.GetType()}");
            Console.ResetColor();
        }
    }
}
