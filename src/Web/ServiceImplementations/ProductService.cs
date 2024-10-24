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
        _httpClient = httpClientFactory.CreateClient("CatalogsService");
    }

    public async Task LoadProductsAsync()
    {
        Products = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("GetProducts");
    }
}
