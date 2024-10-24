using Shared.DTO.Catalogs;

namespace Web.Services;

public interface IProductService
{
    List<ProductDTO> Products {get; set;}

    public Task LoadProductsAsync();

}
