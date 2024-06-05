using Microsoft.AspNetCore.Mvc;
using SmartELK.Domain.Interface.Managers;

namespace SmartELK.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductManager _manager;
    public ProductController(IProductManager manager, ILogger<ProductController> logger)
    {
        _manager = manager;
        _logger = logger;
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> SearchProducts(
        [FromQuery] string query,
        [FromQuery] string? category,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice)
    {
        _logger.LogInformation($"Searching products with query: {query}, category: {category}, minPrice: {minPrice}, maxPrice: {maxPrice}");
        var products = await _manager.SearchProducts(query, category, minPrice, maxPrice);
        return Ok(products);
    }
}