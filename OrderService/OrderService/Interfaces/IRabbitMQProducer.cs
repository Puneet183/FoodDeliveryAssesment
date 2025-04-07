using OrderService.Models;

namespace OrderService.Interfaces
{
    public interface IRabbitMQProducer
    {
        void SendMessage(OrderDto order);
    }
}
