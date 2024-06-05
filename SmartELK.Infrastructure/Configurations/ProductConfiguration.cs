using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartELK.Domain.Entities;

namespace SmartELK.Infrastructure.Configurations;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        var random = new Random();
        var products = new List<Product>();
        
        var categories = new List<string>
        {
            "Beverages", "Condiments", "Confections", "Dairy Products", "Grains/Cereals", 
            "Meat/Poultry", "Produce", "Seafood"
        };

        var productNames = new Dictionary<string, List<string>>
        {
            {"Beverages", new List<string>{"Cola", "Green Tea", "Beer", "Coffee", "Orange Juice"}},
            {"Condiments", new List<string>{"Ketchup", "Mustard", "Soy Sauce", "BBQ Sauce", "Hot Sauce"}},
            {"Confections", new List<string>{"Chocolate Bar", "Gummy Bears", "Cheesecake", "Brownies", "Lollipop"}},
            {"Dairy Products", new List<string>{"Cheddar Cheese", "Milk", "Yogurt", "Butter", "Cream"}},
            {"Grains/Cereals", new List<string>{"Wheat Bread", "Corn Flakes", "Spaghetti", "Rice", "Oatmeal"}},
            {"Meat/Poultry", new List<string>{"Chicken Breast", "Bacon", "Ham", "Steak", "Turkey"}},
            {"Produce", new List<string>{"Apples", "Bananas", "Carrots", "Broccoli", "Spinach"}},
            {"Seafood", new List<string>{"Salmon", "Tuna", "Shrimp", "Crab", "Lobster"}}
        };
        
        var descriptionTemplates = new List<string>
        {
            "High quality {0}",
            "Delicious and fresh {0}",
            "Top-notch {0} for everyone",
            "Premium grade {0}",
            "Best in class {0}",
            "Freshly made {0}",
            "Authentic {0}",
            "Organic and natural {0}",
            "Handpicked {0}",
            "Exquisite {0}"
        };
        
        int productId = 1;
        for (int i = 0; i < 100; i++)
        {
            var categoryIndex = i % categories.Count;
            var categoryName = categories[categoryIndex];
            var productList = productNames[categoryName];
            var name = productList[random.Next(productList.Count)];
            var descriptionTemplate = descriptionTemplates[random.Next(descriptionTemplates.Count)];
            var description = string.Format(descriptionTemplate, name.ToLower());
            products.Add(new Product
            {
                Id = productId,
                Name = $"{name} {productId}",
                Description = description,
                Price = (decimal)(random.Next(100, 10000) / 100.0),
                CategoryId = categoryIndex + 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
            
            productId++;
        }

        builder.HasData(products);
    }
}