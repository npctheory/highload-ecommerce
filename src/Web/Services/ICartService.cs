using Shared.DTO.Catalogs;
using Shared.DTO.Orders;
using Web.Components;

namespace Web.Services;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(ProductDTO product);
    Task<List<CartItem>> GetCartItems();
}