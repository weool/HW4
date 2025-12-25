using Microsoft.AspNetCore.Mvc;
using System;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> _orders = new();

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Amount = request.Amount,
            Status = "Created",
            CreatedAt = DateTime.UtcNow
        };
        
        _orders.Add(order);
        
        return Ok(new
        {
            order.Id,
            order.Status,
            order.Amount,
            order.CreatedAt
        });
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var userOrders = _orders.Where(o => o.UserId == userId).ToList();
        return Ok(userOrders);
    }

    [HttpGet("{orderId}")]
    public IActionResult GetOrder(Guid orderId)
    {
        var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var order = _orders.FirstOrDefault(o => o.Id == orderId && o.UserId == userId);
        
        if (order == null)
            return NotFound();
            
        return Ok(order);
    }
}

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Created";
    public DateTime CreatedAt { get; set; }
}

public class CreateOrderRequest
{
    public decimal Amount { get; set; }
}
