using System.Collections.ObjectModel;

namespace CatalogAPI.Domain;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UrlImage { get; set; }

    
    #region Relationship

    public ICollection<Product>? Products { get; set; }

    #endregion
    
    // anemic class: no behavior
}