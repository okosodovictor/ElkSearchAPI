using SmartELK.Domain.Documents;
using SmartELK.Domain.Interface.Managers;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Domain.Interface.Services;

namespace SmartELK.API.Jobs;

public class ProductSyncService(
    IServiceProvider services,
    ILogger<ProductSyncService> logger)
    : BackgroundService
{
    private DateTime _lastSyncTimestamp = DateTime.UtcNow;
    private readonly ILogger<ProductSyncService> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = services.CreateScope();
                var repository =  scope.ServiceProvider.GetRequiredService<IProductRepository>();
                var elKService =  scope.ServiceProvider.GetRequiredService<IElasticsearchProductService>();
                    
                var products = await repository.GetNewOrModifiedProductsAync(_lastSyncTimestamp);
                if (products.Any())
                {
                    var productDocuments = products.Select(p => new ProductDocument()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt,
                        CategoryId = p.CategoryId,
                        Price = p.Price,
                        CategoryName = p.Category.CategoryName
                    });
                    await elKService.BulkInsertProductsAsync(productDocuments);
                }
    
                _lastSyncTimestamp = DateTime.UtcNow;
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error from job: {ex.Message}");
            }
        }
    }
}