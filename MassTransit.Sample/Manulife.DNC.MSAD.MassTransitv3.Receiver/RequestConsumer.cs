using Manulife.DNC.MSAD.MassTransitv3.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitv3.Receiver
{
    public class RequestConsumer : IConsumer<IRequestMessage>
    {
        public async Task Consume(ConsumeContext<IRequestMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"Received message: Id={context.Message.MessageId}, Content={context.Message.Content}");
            Console.ResetColor();

            var response = new ResponseMessage
            {
                MessageCode = 200,
                Content = $"Success",
                RequestId = context.Message.MessageId
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Response message: Code={response.MessageCode}, Content={response.Content}, RequestId={response.RequestId}");
            Console.ResetColor();
            await context.RespondAsync(response);
        }
    }
}
