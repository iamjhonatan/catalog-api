using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Domain;

[Table("Categories")]
public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string? Name { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string? UrlImage { get; set; }

    
    #region Relationship

    public ICollection<Product>? Products { get; set; }

    #endregion
    
    // anemic class: no behavior
}