using Shared.DTO.Catalogs;
using Web.Services;
using System.Threading.Tasks;

namespace Web.ServiceImplementations;

public class CategoryServiceMockUp : ICategoryService
{
    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

    public async Task LoadCategoriesAsync()
    {
        await Task.Run(() =>
        {
            Categories = new List<CategoryDTO>
            {
                new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                new CategoryDTO { Id = 2, Name = "Спец Предложения", Url = "special-offers", Icon = "icon3" },
                new CategoryDTO { Id = 3, Name = "Премиум", Url = "premium", Icon = "icon4" },
                new CategoryDTO { Id = 4, Name = "Классовые Предложения", Url="class-offers", Icon = "icon5" },
                new CategoryDTO { Id = 5, Name = "Теневая Экипировка", Url="shadow-equipment", Icon = "icon6" },
                new CategoryDTO { Id = 6, Name = "Ежедневные Предложения", Url="daily-offers", Icon = "icon7" }
            };
        });
    }
}