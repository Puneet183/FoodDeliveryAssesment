using OrderService.Interfaces;

public interface IRabbitMQProducer
{
    void SendMessage(Order order);
}