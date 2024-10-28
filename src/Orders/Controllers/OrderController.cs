using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Orders;
using System.Security.Claims;

namespace Orders.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    // Add your order repository/service here
    // private readonly IOrderRepository _orderRepository;

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
        // Inject your order repository/service
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            // Get account ID from JWT token
            var accountIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (accountIdClaim == null)
            {
                return Unauthorized("Invalid token - no account ID found");
            }

            var accountId = int.Parse(accountIdClaim.Value);

            // Create the order
            var order = new OrderDTO
            {
                AccountId = accountId,
                CreatedAt = DateTime.UtcNow,
                Status = "Created",
                Items = request.Items,
                TotalAmount = request.Items.Sum(item => item.Price)
            };

            // Save to database
            // await _orderRepository.CreateOrderAsync(order);

            _logger.LogInformation($"Created order for account {accountId} with {request.Items.Count} items");

            return Ok(order);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating order");
            return StatusCode(500, "An error occurred while creating the order");
        }
    }
}