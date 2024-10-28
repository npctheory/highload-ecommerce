namespace Shared.DTO.Orders;

public class CreateOrderRequest
{
    public List<OrderItemDTO> Items { get; set; }
}