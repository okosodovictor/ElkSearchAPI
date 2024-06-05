using SmartELK.Domain.Documents;

namespace SmartELK.Domain.Interface.Managers;

public interface IProductManager
{
    Task<IEnumerable<ProductDocument>> SearchProducts(string query, string category, decimal? minPrice = null, decimal? maxPrice = null);
}