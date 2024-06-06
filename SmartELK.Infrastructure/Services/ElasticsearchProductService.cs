using System.Text;
using Nest;
using SmartELK.Domain.Documents;
using SmartELK.Domain.Entities;
using SmartELK.Domain.Interface.Services;

namespace SmartELK.Infrastructure.Services;

public class ElasticsearchProductService: IElasticsearchProductService
{
    private readonly IElasticClient _elasticClient;

    public ElasticsearchProductService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }
    
    public async Task<bool> BulkInsertProductsAsync(IEnumerable<ProductDocument> productDocuments)
    {
        var bulkIndexRequest = new BulkDescriptor();
        foreach (var productDocument in productDocuments)
        {
            bulkIndexRequest.Index<ProductDocument>(x => x.Document(productDocument));
        }

        var response = await _elasticClient.BulkAsync(bulkIndexRequest);
        if (!response.IsValid)
        {
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<ProductDocument>> SearchProductsAsync(string query, string categoryName = null, decimal? minPrice = null, decimal? maxPrice = null)
    {
        var searchPhrase = CleanSearchPhrase(query);
        var productQuery = new List<Func<QueryContainerDescriptor<ProductDocument>, QueryContainer>>();
        if (int.TryParse(searchPhrase, out _))
        {
            productQuery.Add(q => q
                .Match(m => m
                    .Field(f => f.Id)
                    .Query(searchPhrase)
                )
            );
        }
        else
        {
            productQuery.Add(q => q
                .MultiMatch(m => m
                    .Fields(f => f
                        .Field(f => f.Name)
                        .Field(f => f.Description)
                    )
                    .Query(searchPhrase)
                )
            );
            
            if (!string.IsNullOrEmpty(categoryName))
            {
                productQuery.Add(q => q
                    .Match(m => m
                        .Field(f => f.CategoryName)
                        .Query(categoryName)
                    )
                );
            }
            
            if (minPrice.HasValue)
            {
                double minPriceDouble = Convert.ToDouble(minPrice.Value);
                productQuery.Add(q => q
                    .Range(r => r
                        .Field(f => f.Price)
                        .GreaterThanOrEquals(minPriceDouble)
                    )
                );
            }
            
            if (maxPrice.HasValue)
            {
                double maxPriceDouble = Convert.ToDouble(maxPrice.Value);
                productQuery.Add(q => q
                    .Range(r => r
                        .Field(f => f.Price)
                        .LessThanOrEquals(maxPriceDouble)
                    )
                );
            }
        }
        
        var response = await _elasticClient.SearchAsync<ProductDocument>(s => s
            .Query(q => q
                .Bool(b => b
                    .Must(productQuery)
                )
            )
        );
       
        if (!response.IsValid)
        {
            throw new Exception($"Search failed: {response.ServerError.Error.Reason}");
        }
        
        return response.Documents;
    }
    
    private string CleanSearchPhrase(string searchPhrase)
    {
        var charsToRemove = new HashSet<char> { ',', '.' };
        var charsToSkip = new HashSet<char> {
            '#', '$', '%', '<', '>', '+', '-', '=', '&', '|', '!', '(', ')',
            '{', '}', '[', ']', '^', '\"', '~', '*', '?', ':', '\\', '/'
        };

        var cleanPhrase = new StringBuilder();
        foreach (var ctx in searchPhrase)
        {
            if (charsToSkip.Contains(ctx))
            {
                cleanPhrase.Append(' ');
            }
            else if (!charsToRemove.Contains(ctx))
            {
                cleanPhrase.Append(ctx);
            }
        }

        return cleanPhrase.ToString().Trim();
    }
}