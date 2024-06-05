using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using SmartELK.Domain.Entities;

namespace SmartELK.Infrastructure.Configurations;

public static class ElasticsearchExtensions
{
    public static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["elasticsearch:url"];
        var defaultIndex = configuration["elasticsearch:index"];
        var username = configuration["elasticsearch:username"];
        var password = configuration["elasticsearch:password"];
        
        var settings = new ConnectionSettings(new Uri(url))
            .DefaultIndex(defaultIndex)
            .BasicAuthentication(username,password);

        var client = new ElasticClient(settings);
        services.AddSingleton<IElasticClient>(client);
        CreateIndex(client, defaultIndex);
        return services;
    }
    
    private static void CreateIndex(IElasticClient client, string indexName)
    {
        var createIndexResponse = client.Indices.Create(indexName,
            index => index.Map<Product>(x => x.AutoMap())
        );
    }
}