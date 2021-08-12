using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672") // username: guest, password: guest
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            QueueConsumer.Consume(channel);
        }
    }
}
