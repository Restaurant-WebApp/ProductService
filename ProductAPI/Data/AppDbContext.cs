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
    }
}
