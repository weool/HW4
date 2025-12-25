using Microsoft.AspNetCore.Mvc;
using System;

namespace PaymentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private static decimal _balance = 1000.00m;
    private static readonly List<Transaction> _transactions = new();

    [HttpPost("account")]
    public IActionResult CreateAccount()
    {
        return Ok(new
        {
            AccountId = Guid.NewGuid(),
            Balance = 0.00m,
            CreatedAt = DateTime.UtcNow
        });
    }

    [HttpGet("balance")]
    public IActionResult GetBalance()
    {
        return Ok(new
        {
            Balance = _balance,
            UpdatedAt = DateTime.UtcNow
        });
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] DepositRequest request)
    {
        if (request.Amount <= 0)
            return BadRequest("Amount must be greater than 0");
            
        _balance += request.Amount;
        
        _transactions.Add(new Transaction
        {
            Id = Guid.NewGuid(),
            Type = "Deposit",
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow
        });
        
        return Ok(new
        {
            Balance = _balance,
            UpdatedAt = DateTime.UtcNow
        });
    }

    [HttpGet("transactions")]
    public IActionResult GetTransactions()
    {
        return Ok(_transactions);
    }
}

public class Transaction
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class DepositRequest
{
    public decimal Amount { get; set; }
}
