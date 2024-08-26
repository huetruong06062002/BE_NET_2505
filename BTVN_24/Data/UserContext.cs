using BTVN_24.Models;
using Microsoft.EntityFrameworkCore;

namespace BTVN_24.Data
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasPrecision(18, 2); // 18 total digits, with 2 decimal places
		}
	}
}
