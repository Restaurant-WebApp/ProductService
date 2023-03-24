using Microsoft.EntityFrameworkCore;
using ProductAPI.Model;

namespace ProductAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Chicken curry",
                    ProductDescription="Delicious chicken curry",
                    ProductCategory= Category.Mains,
                    Price=17,
                    ProductImageUrl=""

                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 2,
                    ProductName = "Chicken momo",
                    ProductDescription = "Nepalese steamed dumplings",
                    ProductCategory = Category.Starter,
                    Price = 10,
                    ProductImageUrl = ""

                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 3,
                    ProductName = "Chicken tandoori",
                    ProductDescription = "Delicious chicken leg piece cooked in fire",
                    ProductCategory = Category.Mains,
                    Price = 15,
                    ProductImageUrl = ""

                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 4,
                    ProductName = "Gulab Jamun",
                    ProductDescription = "Delicious sugar balls",
                    ProductCategory = Category.Mains,
                    Price = 5,
                    ProductImageUrl = ""

                });
        }
    }
}
