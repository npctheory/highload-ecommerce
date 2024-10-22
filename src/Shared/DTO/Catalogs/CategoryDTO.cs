namespace Shared.DTO.Catalogs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public List<ProductDTO> Products { get; set; }
}
