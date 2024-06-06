using SmartELK.Domain.Documents;
using SmartELK.Domain.Interface.Managers;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Domain.Interface.Services;

namespace SmartELK.Domain.Managers;

public class ProductManager : IProductManager
{
    private readonly IElasticsearchProductService _service;

    public ProductManager(IElasticsearchProductService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<ProductDocument>> SearchProducts(string query, string category, decimal? minPrice = null,
        decimal? maxPrice = null)
    {
        var searchResult = await _service.SearchProductsAsync(query, category, minPrice, maxPrice);
        return searchResult;
    }
}
