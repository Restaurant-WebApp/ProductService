using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedFixedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductCategory", "ProductDescription", "ProductImageUrl", "ProductName" },
                values: new object[,]
                {
                    { 1, 17, 1, "Delicious chicken curry", "", "Chicken curry" },
                    { 2, 10, 0, "Nepalese steamed dumplings", "", "Chicken momo" },
                    { 3, 15, 1, "Delicious chicken leg piece cooked in fire", "", "Chicken tandoori" },
                    { 4, 5, 1, "Delicious sugar balls", "", "Gulab Jamun" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
