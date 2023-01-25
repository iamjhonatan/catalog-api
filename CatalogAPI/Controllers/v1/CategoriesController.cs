using CatalogAPI.Domain;
using CatalogAPI.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers.v1;

[Route("v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    
    #region GET
    
    [HttpGet("products")]
    public ActionResult<IEnumerable<Category>> GetAllCategoriesProducts()
    {
        var categories = _context.Categories
            .AsNoTracking()
            .Include(x => x.Products)
            .ToList();

        if (!categories.Any())
            return NotFound("Categories not found.");

        return Ok(categories);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> GetAllCategories()
    {
        // understanding error handling: any error in the ´try´ block, the ´catch´ block will bring a more user friendly message.
        try
        {
            var categories = _context.Categories
                .AsNoTracking() // when a query is needed, without changing data, and that query is done faster, without the object being saved in cache.
                .ToList();

            if (!categories.Any())
                return NotFound("Categories not found.");

            return Ok(categories);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while handling your request.");
        }
    }

    [HttpGet("{id:int}", Name = "getCategory")]
    public ActionResult<Category> GetCategoryById(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);

        if (category is null)
            return NotFound($"Category with ID: {id} not found.");

        return Ok(category);
    }

    #endregion

    
    #region POST

    [HttpPost]
    public ActionResult CreateCategory(Category? category)
    {
        if (category is null)
            return BadRequest("Invalid category.");

        _context.Categories.Add(category);
        _context.SaveChanges();
        
        return new CreatedAtRouteResult("getCategory", new { id = category.Id }, category);
    }

    #endregion


    #region PUT

    [HttpPut("{id:int}")]
    public ActionResult UpdateCategory(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest($"The ID {id} was not found.");

        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(category);
    }

    #endregion


    #region DELETE

    [HttpDelete("{id:int}")]
    public ActionResult<Category> DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);

        if (category is null)
            return NotFound($"Category with ID: {id} was not found.");

        _context.Remove(category);
        _context.SaveChanges();

        return Ok(category);
    }

    #endregion
}