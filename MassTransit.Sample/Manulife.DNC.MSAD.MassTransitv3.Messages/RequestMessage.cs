using System;

namespace Manulife.DNC.MSAD.MassTransitv3.Messages
{
    public interface IRequestMessage
    {
        int MessageId { get; set; }
        string Content { get; set; }
    }

    public class RequestMessage : IRequestMessage
    {
        public int MessageId { get; set; }
        public string Content { get; set; }

        public int RequestId { get; set; }
    }
}
