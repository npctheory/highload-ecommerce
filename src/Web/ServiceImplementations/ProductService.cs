using System.Net.Http.Json;
using Shared.DTO.Catalogs;
using Web.Services;

namespace Web.ServiceImplementations;

public class ProductService : IProductService
{
    public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    private readonly HttpClient _httpClient;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Catalogs");
    }

    public async Task LoadProductsAsync()
    {
        // Update the API endpoint to match your controller's route for getting all products
        Products = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("products");
    }
}
