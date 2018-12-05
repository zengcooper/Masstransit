using System;
using System.Collections.Generic;
using System.Text;

namespace Manulife.DNC.MSAD.MassTransitv3.Messages
{
    public interface IResponseMessage
    {
        int MessageCode { get; set; }
        string Content { get; set; }
    }

    public class ResponseMessage : IResponseMessage
    {
        public int MessageCode { get; set; }
        public string Content { get; set; }

        public int RequestId { get; set; }
    }
}
