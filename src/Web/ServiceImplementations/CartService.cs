using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Shared.DTO.Catalogs;
using Web.Components;
using Web.Services;

namespace Web.ServiceImplementations;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IToastService _toastService;
    private readonly IProductService _productService;

    public event Action OnChange;


    public CartService(ILocalStorageService localStorageService,
        IToastService toastService,
        IProductService productService)
    {
        _localStorageService = localStorageService;
        _toastService = toastService;
        _productService = productService;
    }

    public async Task AddToCart(ProductDTO product)
    {
        var cart = await _localStorageService.GetItemAsync<List<ProductDTO>>("cart");
        if(cart == null)
        {
            cart = new List<ProductDTO>();
        }
        cart.Add(product);
        await _localStorageService.SetItemAsync("cart", cart);

        _toastService.ShowSuccess($"Товар добавлен в корзину");
        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        Console.WriteLine("Fetching cart items from local storage...");
        var result = new List<CartItem>();
        var cart = await _localStorageService.GetItemAsync<List<ProductDTO>>("cart");
        Console.WriteLine($"Local storage cart: {string.Join(", ", cart?.Select(c => c.Title) ?? new List<string>())}");
        
        if(cart == null)
        {
            Console.WriteLine("Cart is empty, returning empty result.");
            return result;
        }

        foreach (var item in cart)
        {
            result.Add(new CartItem { ProductId = item.Id, Title = item.Title, Price = item.Price });
        }
        
        Console.WriteLine($"Resulting cart items: {string.Join(", ", result.Select(r => r.Title))}");
        return result;
    }
}
