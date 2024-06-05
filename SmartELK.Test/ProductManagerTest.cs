using Moq;
using SmartELK.Domain.Documents;
using SmartELK.Domain.Interface.Managers;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Domain.Interface.Services;
using SmartELK.Domain.Managers;

namespace SmartELK.Test;

public class ProductManagerTest
{
    private Mock<IElasticsearchProductService> _mockElasticsearchProductService;
    private Mock<ICategoryRepository> _mockCategoryRepository;
    private IProductManager _productManager;

    [SetUp]
    public void Setup()
    {
        _mockElasticsearchProductService = new Mock<IElasticsearchProductService>();
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _productManager = new ProductManager(_mockElasticsearchProductService.Object, _mockCategoryRepository.Object);
    }

    [Test]
    public async Task SearchProducts_ShouldCallSearchProductsAsync()
    {
        // Arrange
        var query = "test query";
        var category = "test category";
        var minPrice = (decimal?)10.0;
        var maxPrice = (decimal?)50.0;

        var expectedProducts = new List<ProductDocument>
        {
            new ProductDocument { Id = 1, Name = "Product 1", Description = "Description 1", Price = 20.0m, CategoryName = "Category 1" },
            new ProductDocument { Id = 2, Name = "Product 2", Description = "Description 2", Price = 30.0m, CategoryName = "Category 2" }
        };

        _mockElasticsearchProductService
            .Setup(service => service.SearchProductsAsync(query, category, minPrice, maxPrice))
            .ReturnsAsync(expectedProducts);

        // Act
        var result = await _productManager.SearchProducts(query, category, minPrice, maxPrice);
        // Assert
        Assert.NotNull(result);
        Assert.That(result.Count(), Is.EqualTo(expectedProducts.Count));

        _mockElasticsearchProductService
            .Verify(service => service.SearchProductsAsync(query, category, minPrice, maxPrice), Times.Once);
    }
    
    [Test]
    public async Task SearchProducts_ShouldReturnEmptyList_WhenNoProductsMatch()
    {
        // Arrange
        var query = "nonexistent product";
        var category = "nonexistent category";
        var minPrice = (decimal?)100.0;
        var maxPrice = (decimal?)200.0;

        var expectedProducts = new List<ProductDocument>();
        _mockElasticsearchProductService
            .Setup(service => service.SearchProductsAsync(query, category, minPrice, maxPrice))
            .ReturnsAsync(expectedProducts);

        // Act
        var result = await _productManager.SearchProducts(query, category, minPrice, maxPrice);

        // Assert
        Assert.NotNull(result);
        Assert.IsEmpty(result);
        _mockElasticsearchProductService.Verify(service => service.SearchProductsAsync(query, category, minPrice, maxPrice), Times.Once);
    }
    
    [Test]
    public void SearchProducts_ShouldThrowException_WhenServiceThrowsException()
    {
        // Arrange
        var query = "test query";
        var category = "test category";
        var minPrice = (decimal?)10.0;
        var maxPrice = (decimal?)50.0;

        _mockElasticsearchProductService
            .Setup(service => service.SearchProductsAsync(query, category, minPrice, maxPrice))
            .ThrowsAsync(new Exception("Elasticsearch error"));

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await _productManager.SearchProducts(query, category, minPrice, maxPrice));
    }
}