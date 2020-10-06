using System;
using System.Collections.Generic;
using System.Text;

namespace activemq.poc.producer
{
    public interface IQueueMessageSender
    {
        void Send(string message);
    }
}
