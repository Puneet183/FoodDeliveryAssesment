using Newtonsoft.Json;
using OrderService.Interfaces;
using OrderService.Models;
using RabbitMQ.Client;
using System.Text;

namespace OrderService.Repositories
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendMessage(OrderDto order)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "orderQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order));
            channel.BasicPublish(exchange: "", routingKey: "orderQueue", body: body);
        }
    }
}
