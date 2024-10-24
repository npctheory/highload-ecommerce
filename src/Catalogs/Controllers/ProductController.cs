using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Catalogs;

namespace Catalogs.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("/GetProducts")]
    public async Task<ActionResult<List<ProductDTO>>> GetProducts()
    {
        return Ok(Products);
    }

    [HttpGet("/GetProductsByCategory/{categoryUrl}")]
    public async Task<ActionResult<List<ProductDTO>>> GetProductsByCategory(string categoryUrl)
    {
        var products = Products.Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower()).ToList();
        if (products.Count == 0)
        {
            return NotFound($"No products found in category: {categoryUrl}");
        }
        return Ok(products);
    }

    [HttpGet("GetProduct/{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound($"Product with id {id} not found");
        }
        return Ok(product);
    }

    private static List<ProductDTO> Products {get; set;} = new List<ProductDTO>
        {
            new ProductDTO
            {
                Id = 1,
                Title = "Набор с Песьей фуражкой",
                Description = "Набор с Песьей фуражкой",
                Price = 499.00m,
                OriginalPrice = 864.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 1,
                DateCreated = DateTime.UtcNow.AddDays(-10),
                DateUpdated = DateTime.UtcNow.AddDays(-5)
            },
            new ProductDTO
            {
                Id = 2,
                Title = "Набор Серафинга",
                Description = "Набор Серафинга",
                Price = 399.00m,
                OriginalPrice = 664.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 1,
                DateCreated = DateTime.UtcNow.AddDays(-12),
                DateUpdated = DateTime.UtcNow.AddDays(-6)
            },
            new ProductDTO
            {
                Id = 3,
                Title = "Шапка хитрюги Смоки",
                Description = "Шапка хитрюги Смоки",
                Price = 790.00m,
                OriginalPrice = 790.00m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 2, Name = "Спец Предложения", Url = "special_offers", Icon = "icon3" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 2,
                DateCreated = DateTime.UtcNow.AddDays(-15),
                DateUpdated = DateTime.UtcNow.AddDays(-8)
            },
            new ProductDTO
            {
                Id = 4,
                Title = "Набор с Треуголкой",
                Description = "Набор с Треуголкой",
                Price = 399.00m,
                OriginalPrice = 724.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 2, Name = "Спец Предложения", Url = "special_offers", Icon = "icon3" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 2,
                DateCreated = DateTime.UtcNow.AddDays(-15),
                DateUpdated = DateTime.UtcNow.AddDays(-8)
            },
            new ProductDTO
            {
                Id = 5,
                Title = "Набор с Демоническим нимбом",
                Description = "Набор с Демоническим нимбом",
                Price = 399.00m,
                OriginalPrice = 664.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 2, Name = "Спец Предложения", Url = "special_offers", Icon = "icon3" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 2,
                DateCreated = DateTime.UtcNow.AddDays(-18),
                DateUpdated = DateTime.UtcNow.AddDays(-9)
            },
            new ProductDTO
            {
                Id = 6,
                Title = "Набор с Шлемом генерала",
                Description = "Набор с Шлемом генерала",
                Price = 449.00m,
                OriginalPrice = 764.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 3, Name = "Премиум", Url = "premium", Icon = "icon4" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 3,
                DateCreated = DateTime.UtcNow.AddDays(-20),
                DateUpdated = DateTime.UtcNow.AddDays(-10)
            },
            new ProductDTO
            {
                Id = 7,
                Title = "Набор чернокнижника",
                Description = "Набор чернокнижника",
                Price = 1550.00m,
                OriginalPrice = 1847.00m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 3, Name = "Премиум", Url = "premium", Icon = "icon4" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 3,
                DateCreated = DateTime.UtcNow.AddDays(-20),
                DateUpdated = DateTime.UtcNow.AddDays(-12)
            },
            new ProductDTO
            {
                Id = 8,
                Title = "Набор ларцов близнецов",
                Description = "Набор ларцов близнецов",
                Price = 801.00m,
                OriginalPrice = 1050.00m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 3, Name = "Премиум", Url = "premium", Icon = "icon4" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 3,
                DateCreated = DateTime.UtcNow.AddDays(-22),
                DateUpdated = DateTime.UtcNow.AddDays(-14)
            },
            new ProductDTO
            {
                Id = 9,
                Title = "Набор с Ободком с пробирками",
                Description = "Набор  Ободка с пробирками",
                Price = 799.00m,
                OriginalPrice = 1173.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 3, Name = "Премиум", Url = "premium", Icon = "icon4" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 3,
                DateCreated = DateTime.UtcNow.AddDays(-25),
                DateUpdated = DateTime.UtcNow.AddDays(-16)
            }
        };
}