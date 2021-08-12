using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    public static class DirectExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);
            channel.QueueDeclare("demo-direct-queue", durable: true,
               exclusive: false,
               autoDelete: false,
               arguments: null);
            // channel.QueueBind("demo-direct-exchange", "demo-direct-exchange", "aacount.init");
            channel.QueueBind(queue: "demo-direct-exchange",
                   exchange: "demo-direct-exchange",
                   routingKey: "aacount.init");
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume("demo-direct-exchange", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
