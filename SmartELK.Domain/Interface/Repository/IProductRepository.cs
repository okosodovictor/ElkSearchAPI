using SmartELK.Domain.Entities;

namespace SmartELK.Domain.Interface.Repository;

public interface IProductRepository
{
    Task<List<Product>> GetNewOrModifiedProductsAync(DateTime lastSyncTimestamp);
}