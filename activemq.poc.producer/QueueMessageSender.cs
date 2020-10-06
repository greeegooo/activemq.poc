using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;

namespace activemq.poc.producer
{
    public class QueueMessageSender : IQueueMessageSender
    {
        private readonly Uri _broker = new Uri("tcp://localhost:61616");
        private readonly string _queueName = "activemq.poc.queue";

        public void Send(string message)
        {
            try
            {
                IConnectionFactory factory = new ConnectionFactory(_broker);
                IConnection connection = factory.CreateConnection();
                connection.Start();
                ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
                IDestination destination = session.GetQueue(_queueName);
                using(IMessageProducer producer = session.CreateProducer(destination))
                {
                    var queueMessage = producer.CreateTextMessage(message);
                    producer.Send(queueMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
