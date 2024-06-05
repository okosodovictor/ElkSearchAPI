using Microsoft.EntityFrameworkCore;
using SmartELK.API.Jobs;
using SmartELK.Domain.Interface.Managers;
using SmartELK.Domain.Interface.Repository;
using SmartELK.Domain.Interface.Services;
using SmartELK.Domain.Managers;
using SmartELK.Infrastructure.Configurations;
using SmartELK.Infrastructure.Database;
using SmartELK.Infrastructure.Repositories;
using SmartELK.Infrastructure.Services;

namespace SmartELK.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //build config
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        
        var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = builder.Configuration["ConnectionStrings:ProductDB"];
        }

        builder.Services.AddDbContext<ProductsContext>(options =>
            options.UseNpgsql(connectionString));
        
        builder.Services.AddPersistence(config);
        builder.Services.AddElasticsearch(builder.Configuration);
        
        builder.Services.AddScoped<IElasticsearchProductService, ElasticsearchProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductManager, ProductManager>();
        
        builder.Services.AddHostedService<ProductSyncService>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}