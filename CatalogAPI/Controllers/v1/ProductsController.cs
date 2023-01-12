using CatalogAPI.Domain;
using CatalogAPI.Persistence.Context;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers.v1;

[Route("v1/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        var products = _context.Products.ToList();

        if (products is null)
            return NotFound("Products not found.");

        return products;
    }

    [HttpGet("{id:int}")] // defining that parameter to be passed via URL must be the product ID, int 
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

        if (product is null)
            return NotFound("Product not found.");

        return product;
    }
}