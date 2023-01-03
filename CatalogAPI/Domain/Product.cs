namespace CatalogAPI.Domain;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? UrlImage { get; set; }
    public float Stock { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    // anemic class: no behavior
}