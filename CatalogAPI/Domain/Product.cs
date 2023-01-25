using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogAPI.Domain;

[Table("Products")]
public class Product
{
    [Key]
    public int ProductId { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string? Name { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? Description { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2")]
    public decimal Price { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? UrlImage { get; set; }
    
    public float Stock { get; set; }
    public DateTime RegistrationDate { get; set; }

    
    #region Relationship

    public int CategoryId { get; set; }
    
    [JsonIgnore]
    public Category? Category { get; set; }

    #endregion
    
    // anemic class: no behavior
}