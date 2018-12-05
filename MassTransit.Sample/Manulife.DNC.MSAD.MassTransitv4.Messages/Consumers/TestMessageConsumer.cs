using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitv4.Messages
{
    public class TestMessageConsumer : IConsumer<TestMessage>
    {
        public async Task Consume(ConsumeContext<TestMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"TestMessageConsumer => Type:{context.Message.GetType()}, ID:{context.Message.MessageId}, Content:{context.Message.Content}");
            Console.ResetColor();
        }
    }
}
