namespace Shared.DTO.Orders;

public class OrderDTO
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public List<OrderItemDTO> Items { get; set; }
    public decimal TotalAmount { get; set; }
}