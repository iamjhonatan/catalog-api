namespace CatalogAPI.Domain;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UrlImage { get; set; }
    
    // anemic class: no behavior
}