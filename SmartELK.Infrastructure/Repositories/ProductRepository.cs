using Microsoft.EntityFrameworkCore;
using SmartELK.Domain.Entities;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Infrastructure.Database;

namespace SmartELK.Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ProductsContext _dbContext;
    
    public ProductRepository(ProductsContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Product>> GetNewOrModifiedProductsAync(DateTime lastSyncTimestamp)
    {
        return await _dbContext.Products
            .Include(c => c.Category)
            .Where(p => p.UpdatedAt >= lastSyncTimestamp || p.CreatedAt >= lastSyncTimestamp)
            .ToListAsync();
    }
}