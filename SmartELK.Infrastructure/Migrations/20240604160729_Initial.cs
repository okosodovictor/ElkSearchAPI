using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartELK.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Beverages", "Soft drinks, coffees, teas, beers, and ales" },
                    { 2, "Condiments", "Sweet and savory sauces, relishes, spreads, and seasonings" },
                    { 3, "Confections", "Desserts, candies, and sweet breads" },
                    { 4, "Dairy Products", "Cheeses, milk, and yogurts" },
                    { 5, "Grains/Cereals", "Breads, crackers, pasta, and cereal" },
                    { 6, "Meat/Poultry", "Prepared meats" },
                    { 7, "Produce", "Dried fruit and bean curd" },
                    { 8, "Seafood", "Seaweed and fish" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9510), "Handpicked beer", "Beer 1", 49.24m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9510) },
                    { 2, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9520), "Premium grade mustard", "Mustard 2", 48.34m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9520) },
                    { 3, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9530), "Authentic gummy bears", "Gummy Bears 3", 45.34m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9530) },
                    { 4, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9530), "Authentic cheddar cheese", "Cheddar Cheese 4", 47.18m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9530) },
                    { 5, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9530), "Premium grade oatmeal", "Oatmeal 5", 74.82m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9530) },
                    { 6, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9540), "High quality steak", "Steak 6", 37.46m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9540) },
                    { 7, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9540), "Delicious and fresh bananas", "Bananas 7", 9.78m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9540) },
                    { 8, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9550), "Top-notch crab for everyone", "Crab 8", 30.98m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9550) },
                    { 9, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9550), "Authentic beer", "Beer 9", 71.3m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9550) },
                    { 10, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9560), "Freshly made ketchup", "Ketchup 10", 93.85m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9560) },
                    { 11, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9560), "Delicious and fresh lollipop", "Lollipop 11", 20.55m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9560) },
                    { 12, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9570), "Exquisite milk", "Milk 12", 49.73m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9570) },
                    { 13, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9570), "Exquisite corn flakes", "Corn Flakes 13", 93.39m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9570) },
                    { 14, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9570), "Exquisite ham", "Ham 14", 34.37m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9570) },
                    { 15, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9580), "Top-notch carrots for everyone", "Carrots 15", 65.91m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9580) },
                    { 16, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9580), "Handpicked tuna", "Tuna 16", 31.71m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9580) },
                    { 17, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9590), "Premium grade beer", "Beer 17", 89.56m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9590) },
                    { 18, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9590), "Best in class soy sauce", "Soy Sauce 18", 47.53m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9590) },
                    { 19, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9590), "Top-notch gummy bears for everyone", "Gummy Bears 19", 56.11m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9590) },
                    { 20, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9600), "Premium grade cream", "Cream 20", 30.5m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9600) },
                    { 21, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9600), "Authentic oatmeal", "Oatmeal 21", 43.44m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9600) },
                    { 22, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9610), "Delicious and fresh turkey", "Turkey 22", 14.71m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9610) },
                    { 23, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9610), "Top-notch bananas for everyone", "Bananas 23", 18.68m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9610) },
                    { 24, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9610), "Premium grade shrimp", "Shrimp 24", 73.3m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9610) },
                    { 25, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9620), "High quality green tea", "Green Tea 25", 95.57m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9620) },
                    { 26, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9620), "Top-notch soy sauce for everyone", "Soy Sauce 26", 30.34m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9620) },
                    { 27, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9620), "Exquisite chocolate bar", "Chocolate Bar 27", 20.02m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9630) },
                    { 28, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9630), "Premium grade milk", "Milk 28", 91.79m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9630) },
                    { 29, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9630), "Exquisite spaghetti", "Spaghetti 29", 38.52m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9630) },
                    { 30, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9640), "Top-notch turkey for everyone", "Turkey 30", 3.8m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9640) },
                    { 31, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9680), "Top-notch apples for everyone", "Apples 31", 91.84m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9680) },
                    { 32, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9690), "Top-notch salmon for everyone", "Salmon 32", 7.05m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9690) },
                    { 33, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9690), "High quality beer", "Beer 33", 65.5m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9690) },
                    { 34, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9700), "Freshly made mustard", "Mustard 34", 47.48m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9700) },
                    { 35, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9700), "Authentic chocolate bar", "Chocolate Bar 35", 36.13m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9700) },
                    { 36, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9700), "Authentic cream", "Cream 36", 28.58m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9700) },
                    { 37, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9710), "Top-notch corn flakes for everyone", "Corn Flakes 37", 64.04m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9710) },
                    { 38, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9710), "Organic and natural chicken breast", "Chicken Breast 38", 36.64m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9710) },
                    { 39, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9720), "Top-notch apples for everyone", "Apples 39", 49.22m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9720) },
                    { 40, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9720), "Delicious and fresh shrimp", "Shrimp 40", 49.52m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9720) },
                    { 41, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9720), "Freshly made beer", "Beer 41", 17.68m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9720) },
                    { 42, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9730), "Best in class soy sauce", "Soy Sauce 42", 33.36m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9730) },
                    { 43, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9730), "Top-notch chocolate bar for everyone", "Chocolate Bar 43", 16.08m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9730) },
                    { 44, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9730), "Exquisite milk", "Milk 44", 24.6m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9730) },
                    { 45, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9740), "Exquisite spaghetti", "Spaghetti 45", 72.06m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9740) },
                    { 46, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9740), "Exquisite ham", "Ham 46", 62.06m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9740) },
                    { 47, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9740), "Freshly made spinach", "Spinach 47", 45.23m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9740) },
                    { 48, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9750), "Authentic salmon", "Salmon 48", 28.37m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9750) },
                    { 49, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9750), "Freshly made beer", "Beer 49", 3.79m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9750) },
                    { 50, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9750), "Exquisite hot sauce", "Hot Sauce 50", 51.72m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9760) },
                    { 51, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9760), "Premium grade cheesecake", "Cheesecake 51", 41.75m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9760) },
                    { 52, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9760), "Top-notch yogurt for everyone", "Yogurt 52", 41.89m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9760) },
                    { 53, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9770), "Delicious and fresh oatmeal", "Oatmeal 53", 81.45m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9770) },
                    { 54, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9770), "Handpicked steak", "Steak 54", 85.64m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9770) },
                    { 55, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9770), "Top-notch broccoli for everyone", "Broccoli 55", 35.37m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9770) },
                    { 56, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9780), "Exquisite crab", "Crab 56", 56.39m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9780) },
                    { 57, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9780), "Top-notch cola for everyone", "Cola 57", 18.86m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9780) },
                    { 58, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9780), "Organic and natural bbq sauce", "BBQ Sauce 58", 15.6m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9780) },
                    { 59, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9790), "Premium grade gummy bears", "Gummy Bears 59", 58.66m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9790) },
                    { 60, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9790), "Organic and natural yogurt", "Yogurt 60", 83.12m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9790) },
                    { 61, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9800), "Best in class rice", "Rice 61", 63.49m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9800) },
                    { 62, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9800), "Authentic turkey", "Turkey 62", 58.07m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9800) },
                    { 63, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9800), "High quality broccoli", "Broccoli 63", 61.74m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9800) },
                    { 64, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9840), "Premium grade shrimp", "Shrimp 64", 29.06m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9840) },
                    { 65, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9840), "Top-notch beer for everyone", "Beer 65", 51.67m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9840) },
                    { 66, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9850), "Delicious and fresh ketchup", "Ketchup 66", 51.53m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9850) },
                    { 67, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9850), "Organic and natural lollipop", "Lollipop 67", 15.93m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9850) },
                    { 68, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9860), "Authentic cream", "Cream 68", 84.98m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9860) },
                    { 69, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9860), "Delicious and fresh oatmeal", "Oatmeal 69", 63.87m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9860) },
                    { 70, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9860), "Top-notch turkey for everyone", "Turkey 70", 11.97m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9860) },
                    { 71, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9870), "Freshly made bananas", "Bananas 71", 24.95m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9870) },
                    { 72, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9870), "Exquisite lobster", "Lobster 72", 95.18m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9870) },
                    { 73, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9870), "Exquisite coffee", "Coffee 73", 22.33m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9870) },
                    { 74, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9880), "Handpicked soy sauce", "Soy Sauce 74", 9.69m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9880) },
                    { 75, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9880), "Freshly made chocolate bar", "Chocolate Bar 75", 55.9m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9880) },
                    { 76, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9880), "Best in class yogurt", "Yogurt 76", 14.9m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9890) },
                    { 77, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9890), "High quality spaghetti", "Spaghetti 77", 19.69m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9890) },
                    { 78, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9890), "Premium grade bacon", "Bacon 78", 2.03m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9890) },
                    { 79, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9900), "Freshly made spinach", "Spinach 79", 48.94m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9900) },
                    { 80, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9900), "Handpicked salmon", "Salmon 80", 83.89m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9900) },
                    { 81, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9900), "Premium grade coffee", "Coffee 81", 3.13m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9900) },
                    { 82, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9910), "Handpicked bbq sauce", "BBQ Sauce 82", 71.99m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9910) },
                    { 83, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9910), "Handpicked cheesecake", "Cheesecake 83", 41.05m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9910) },
                    { 84, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9910), "High quality milk", "Milk 84", 74.41m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9910) },
                    { 85, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9920), "Delicious and fresh spaghetti", "Spaghetti 85", 7.15m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9920) },
                    { 86, 6, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9920), "Delicious and fresh turkey", "Turkey 86", 41.13m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9920) },
                    { 87, 7, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9930), "Premium grade carrots", "Carrots 87", 98.51m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9930) },
                    { 88, 8, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9930), "Top-notch salmon for everyone", "Salmon 88", 48.83m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9930) },
                    { 89, 1, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9930), "Best in class orange juice", "Orange Juice 89", 36.72m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9930) },
                    { 90, 2, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9940), "Best in class mustard", "Mustard 90", 98.77m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9940) },
                    { 91, 3, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9940), "Best in class chocolate bar", "Chocolate Bar 91", 40.91m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9940) },
                    { 92, 4, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9940), "Delicious and fresh cheddar cheese", "Cheddar Cheese 92", 36.82m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9940) },
                    { 93, 5, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9950), "Delicious and fresh rice", "Rice 93", 85.34m, new DateTime(2024, 6, 4, 16, 7, 29, 343, DateTimeKind.Utc).AddTicks(9950) },
                    { 94, 6, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(30), "Organic and natural ham", "Ham 94", 2.85m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(30) },
                    { 95, 7, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(40), "Organic and natural broccoli", "Broccoli 95", 46.52m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(40) },
                    { 96, 8, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(40), "High quality lobster", "Lobster 96", 91.12m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(40) },
                    { 97, 1, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(40), "Best in class beer", "Beer 97", 48.09m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(50) },
                    { 98, 2, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(50), "Authentic ketchup", "Ketchup 98", 90.25m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(50) },
                    { 99, 3, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(50), "Premium grade chocolate bar", "Chocolate Bar 99", 82.57m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(50) },
                    { 100, 4, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(60), "High quality milk", "Milk 100", 6.74m, new DateTime(2024, 6, 4, 16, 7, 29, 344, DateTimeKind.Utc).AddTicks(60) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
