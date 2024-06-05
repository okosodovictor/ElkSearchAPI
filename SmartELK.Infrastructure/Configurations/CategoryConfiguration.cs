using SmartELK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartELK.Infrastructure.Configurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Beverages",
                Description = "Soft drinks, coffees, teas, beers, and ales"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Condiments",
                Description = "Sweet and savory sauces, relishes, spreads, and seasonings"
            },
            new Category
            {
                CategoryId = 3,
                CategoryName = "Confections",
                Description = "Desserts, candies, and sweet breads"
            },
            new Category
            {
                CategoryId = 4,
                CategoryName = "Dairy Products",
                Description = "Cheeses, milk, and yogurts"
            },
            new Category
            {
                CategoryId = 5,
                CategoryName = "Grains/Cereals",
                Description = "Breads, crackers, pasta, and cereal"
            },
            new Category
            {
                CategoryId = 6,
                CategoryName = "Meat/Poultry",
                Description = "Prepared meats"
            },
            new Category
            {
                CategoryId = 7,
                CategoryName = "Produce",
                Description = "Dried fruit and bean curd"
            },
            new Category
            {
                CategoryId = 8,
                CategoryName = "Seafood",
                Description = "Seaweed and fish"
            });
    }
}