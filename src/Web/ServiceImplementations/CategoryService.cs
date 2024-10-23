using Shared.DTO.Catalogs;
using Web.Services;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;

namespace Web.ServiceImplementations;

public class CategoryService : ICategoryService
{
    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    private readonly HttpClient _httpClient;

    public CategoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("CatalogsService");
    }

    public async Task LoadCategoriesAsync()
    {
        Categories = await _httpClient.GetFromJsonAsync<List<CategoryDTO>>("/api/category");
    }
}