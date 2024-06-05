using SmartELK.Domain.Documents;
using SmartELK.Domain.Entities;

namespace SmartELK.Domain.Interface.Services;

public interface IElasticsearchProductService
{
    Task<bool> BulkInsertProductsAsync(IEnumerable<ProductDocument> products);
    Task<IEnumerable<ProductDocument>> SearchProductsAsync(string query, string category = null, decimal? minPrice = null, decimal? maxPrice = null);
}