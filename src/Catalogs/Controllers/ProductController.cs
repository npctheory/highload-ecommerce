using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Catalogs;

namespace Catalogs.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("products")]
    public async Task<ActionResult<List<ProductDTO>>> GetProducts()
    {
        return Ok(Products);
    }

    [AllowAnonymous]
    [HttpGet("products/category/{categoryUrl}")]
    public async Task<ActionResult<List<ProductDTO>>> GetProductsByCategory(string categoryUrl)
    {
        var products = Products.Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower()).ToList();
        if (products.Count == 0)
        {
            return NotFound($"No products found in category: {categoryUrl}");
        }
        return Ok(products);
    }

    [AllowAnonymous]
    [HttpGet("products/{id}")]
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
                Id = 19265,
                Title = "Шапка хитрюги Смоки",
                Description = "Шапка хитрюги Смоки",
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
                Id = 12921,
                Title = "Ящик оридекона (10 шт.)",
                Description = "Ящик оридекона (10 шт.)",
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
                Id = 12922,
                Title = "Ящик Зигфрида",
                Description = "Ящик Зигфрида",
                Price = 790.00m,
                OriginalPrice = 790.00m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 1,
                DateCreated = DateTime.UtcNow.AddDays(-15),
                DateUpdated = DateTime.UtcNow.AddDays(-8)
            },
            new ProductDTO
            {
                Id = 6046,
                Title = "Купон на покраску",
                Description = "Купон на покраску",
                Price = 399.00m,
                OriginalPrice = 724.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 1,
                DateCreated = DateTime.UtcNow.AddDays(-15),
                DateUpdated = DateTime.UtcNow.AddDays(-8)
            },
            new ProductDTO
            {
                Id = 6047,
                Title = "Купон модельера",
                Description = "Купон модельера",
                Price = 399.00m,
                OriginalPrice = 664.50m,
                Image = "/images/product.webp",
                Category = new CategoryDTO { Id = 1, Name = "Скидки", Url = "discounts", Icon = "icon2" },
                IsPublic = true,
                IsDeleted = false,
                CategoryId = 1,
                DateCreated = DateTime.UtcNow.AddDays(-18),
                DateUpdated = DateTime.UtcNow.AddDays(-9)
            }
        };
}