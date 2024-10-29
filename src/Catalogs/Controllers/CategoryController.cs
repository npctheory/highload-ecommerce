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
        Response.Headers.Add("X-Catalogs-Instance", Environment.GetEnvironmentVariable("INSTANCE_ID") ?? "unknown");
        return Ok(new List<CategoryDTO>
            {
                new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                new CategoryDTO { Id = 2, Name = "Спец Предложения", Url = "special_offers", Icon = "icon3" }
            });
    }
}