using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("demo-queue-exchange",ExchangeType.Direct);
            var count = 0;
            while (true)
            {
                var message = new { name = "Producer", Message = $"Hello! count: { count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("demo-queue-exchange", "aacount.init", null, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}
