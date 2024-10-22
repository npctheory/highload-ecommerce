using Shared.DTO.Catalogs;
using System.Threading.Tasks;

namespace Web.Services;

public interface ICategoryService
{
    public List<CategoryDTO> Categories { get; set; }

    public Task LoadCategoriesAsync();
}