namespace Shared.DTO.Catalogs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public string Image { get; set; }
    public CategoryDTO Category { get; set; }
    public bool IsPublic { get; set; }
    public bool IsDeleted { get; set; }
    public int CategoryId { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; }
}

