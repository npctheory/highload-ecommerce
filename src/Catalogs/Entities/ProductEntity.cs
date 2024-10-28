namespace Catalogs.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public string Image { get; set; }
    public bool IsPublic { get; set; }
    public bool IsDeleted { get; set; }
    public int CategoryId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}