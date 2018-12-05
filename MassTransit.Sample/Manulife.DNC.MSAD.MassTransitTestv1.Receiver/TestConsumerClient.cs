using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitTestv1.Receiver
{
    public class TestConsumerClient : IConsumer<Client>
    {
        public async Task Consume(ConsumeContext<Client> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"Receive message: {context.Message.Id}, {context.Message.Name}, {context.Message.Birthdate.ToString()}");
            Console.ResetColor();
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Message { get; set; }
    }
}
