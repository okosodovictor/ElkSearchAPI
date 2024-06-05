using Microsoft.EntityFrameworkCore;
using SmartELK.Domain.Entities;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Infrastructure.Database;

namespace SmartELK.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductsContext _dbContext;
    
    public CategoryRepository(ProductsContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return  await _dbContext.Categories.ToListAsync();
    }
}