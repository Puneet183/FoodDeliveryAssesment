using DeliveryService.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class RabbitMQConsumerService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();     

        channel.QueueDeclare(
            queue: "orderQueue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var order = JsonConvert.DeserializeObject<OrderDto>(message);

            var partner = new DeliveryPartner
            {
                Id = 1,
                Name = "Ravi",
                PhoneNumber = "1234567890",
                IsAvailable = true
            };

            if (partner.IsAvailable)
            {
                partner.IsAvailable = false;
                Console.WriteLine($"✅ Assigned {partner.Name} to order for FoodItemId: {order.FoodItemId}");
            }
            else
            {
                Console.WriteLine("❌ No available delivery partner.");
            }
        };

        channel.BasicConsume(
            queue: "orderQueue",
            autoAck: true,
            consumer: consumer
        );

        return Task.CompletedTask;
    }
}
