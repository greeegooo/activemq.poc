using System;

namespace activemq.poc.producer
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueueMessageSender sender = new QueueMessageSender();

            sender.Send("Hola Cola!");
        }
    }
}
