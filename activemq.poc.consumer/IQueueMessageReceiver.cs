using System;
using System.Collections.Generic;
using System.Text;

namespace activemq.poc.consumer
{
    public interface IQueueMessageReceiver
    {
        public void Receive();
    }
}
