using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using SmartELK.Domain.Entities;
using SmartELK.Infrastructure.Database;

namespace SmartELK.Infrastructure.Configurations;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductsContext>(options =>
            options.UseNpgsql(configuration["ConnectionStrings:ProductDB"]));

        return services;
    }
}