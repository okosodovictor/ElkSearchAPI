using SmartELK.Domain.Entities;

namespace SmartELK.Domain.Interface.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetNewOrModifiedProductsAync(DateTime lastSyncTimestamp);
}