using RabbitMQ.Client;
using System;

namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Uri = new Uri("amqp://guest:guest@localhost:5672") // username: guest, password: guest
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //QueueProducer.Publish(channel);
            //DirectExchangePublisher.Publish(channel);
            //TopicExchangePublisher.Publish(channel);
            //HeaderExchangePublisher.Publish(channel);
            FanoutExchangePublisher.Publish(channel);

        }
    }
}
