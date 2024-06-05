using SmartELK.Domain.Entities;

namespace SmartELK.Domain.Interface.Repository;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoryAsync();
}