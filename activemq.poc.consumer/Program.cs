using System;

namespace activemq.poc.consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueueMessageReceiver receiver = new QueueMessageReceiver();

            receiver.Receive();
        }
    }
}
