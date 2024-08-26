using BTVN_23_API_ASP.net_core.Models;
using Microsoft.EntityFrameworkCore;

namespace BTVN_23_API_ASP.net_core.DB
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name)
					  .IsRequired()
					  .HasMaxLength(100);

				entity.Property(e => e.Description)
					  .HasMaxLength(500);

				entity.Property(e => e.Price)
					  .IsRequired();

				entity.Property(e => e.IsActive)
					  .IsRequired();
			});
		}
	}
}
