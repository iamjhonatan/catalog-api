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
    
    
}