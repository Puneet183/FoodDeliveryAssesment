using Microsoft.AspNetCore.Mvc;
using OrderService.Interfaces;
using OrderService.Models;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IRabbitMQProducer _producer;

    public OrderController(IRabbitMQProducer producer)
    {
        _producer = producer;
    }

    [HttpPost("place")]
    public IActionResult PlaceOrder([FromBody] OrderDto order)
    {
        _producer.SendMessage(order);
        return Ok("Order placed.");
    }
}