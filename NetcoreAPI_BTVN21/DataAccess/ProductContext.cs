using Microsoft.EntityFrameworkCore;
using NetcoreAPI_BTVN21.Models;

namespace NetcoreAPI_BTVN21.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
