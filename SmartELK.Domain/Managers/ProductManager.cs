using SmartELK.Domain.Documents;
using SmartELK.Domain.Interface.Managers;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Domain.Interface.Services;

namespace SmartELK.Domain.Managers;

public class ProductManager : IProductManager
{
    private readonly IElasticsearchProductService _service;
    private readonly ICategoryRepository _repository;

    public ProductManager(IElasticsearchProductService service, 
        ICategoryRepository repository)
    {
        _service = service;
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDocument>> SearchProducts(string query, string category, decimal? minPrice = null,
        decimal? maxPrice = null)
    {
        var searchResult = await _service.SearchProductsAsync(query, category, minPrice, maxPrice);
        return searchResult;
    }
}