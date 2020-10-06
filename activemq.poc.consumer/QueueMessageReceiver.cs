using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace activemq.poc.consumer
{
    public class QueueMessageReceiver : IQueueMessageReceiver
    {
        private readonly Uri _broker = new Uri("tcp://localhost:61616");
        private readonly string _queueName = "activemq.poc.queue";

        public void Receive()
        {
            try
            {
                IConnectionFactory factory = new ConnectionFactory(_broker);
                IConnection connection = factory.CreateConnection();
                connection.Start();
                ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
                IDestination destination = session.GetQueue(_queueName);
                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    IMessage queueMessage = consumer.Receive();
                    
                    if(queueMessage is ITextMessage)
                    {
                        ITextMessage textMessage = queueMessage as ITextMessage;
                        Console.WriteLine("Message received");
                        Console.WriteLine($"{textMessage.Text}");
                    }
                    else
                    {
                        Console.WriteLine("Unexpected message type: " + queueMessage.GetType().Name);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
