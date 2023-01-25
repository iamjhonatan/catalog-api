using CatalogAPI.Domain;
using CatalogAPI.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers.v1;

[Route("v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    #region GET

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        var products = _context.Products
            .AsNoTracking()
            .ToList();

        if (products is null)
            return NotFound("Products not found.");

        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "getProduct")] // defining that parameter to be passed via URL must be the product ID, int and naming his route
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

        if (product is null)
            return NotFound($"Product with ID: {id} was not found.");

        return Ok(product);
    }
    
    #endregion

    #region POST

    [HttpPost]
    public ActionResult CreateProduct(Product product)
    {
        if (product is null)
            return BadRequest("Invalid product.");
        
        _context.Products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("getProduct", new { id = product.ProductId }, product);
    }
    
    #endregion
    

    #region PUT

    [HttpPut("{id:int}")]
    public ActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.ProductId)
            return BadRequest($"Product with ID: {id} was not found.");

        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(product);
    }

    #endregion


    #region DELETE

    [HttpDelete("{id:int}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

        if (product is null)
            return NotFound($"Product with ID: {id} was not found.");

        _context.Products.Remove(product);
        _context.SaveChanges();

        return Ok(product);
    }

    #endregion
}