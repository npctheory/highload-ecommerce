using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Catalogs;

namespace Catalogs.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("categories")]
    public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
    {
        return Ok(new List<CategoryDTO>
            {
                new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                new CategoryDTO { Id = 2, Name = "Спец Предложения", Url = "special_offers", Icon = "icon3" },
                new CategoryDTO { Id = 3, Name = "Премиум", Url = "premium", Icon = "icon4" },
                new CategoryDTO { Id = 4, Name = "Классовые Предложения", Url="class_offers", Icon = "icon5" },
                new CategoryDTO { Id = 5, Name = "Теневая Экипировка", Url="shadow_equipment", Icon = "icon6" },
                new CategoryDTO { Id = 6, Name = "Ежедневные Предложения", Url="daily_offers", Icon = "icon7" }
            });
    }
}