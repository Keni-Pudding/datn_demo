using DATN_Demo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DATN_Demo.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{



		}

		public DbSet<User> Users { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<ProductDetail> ProductDetails { get; set; }	
		public DbSet<Color> Colors { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			builder.Entity<Cart>().HasOne(u => u.User).WithOne(c => c.Cart);

			builder.Entity<User>().HasOne(r => r.Roles).WithMany(u => u.Users).HasForeignKey(u => u.RoleID);

			builder.Entity<ProductDetail>().HasOne(c => c.Color).WithMany(pd => pd.ProductDetails).HasForeignKey(pd=>pd.ColorID);

			builder.Entity<ProductDetail>().HasOne(s => s.Size).WithMany(pd => pd.ProductDetails).HasForeignKey(pd => pd.SizeID);

			builder.Entity<Product>().HasOne(b=>b.Brand).WithMany(p=>p.Products).HasForeignKey(p=>p.BrandID);

			builder.Entity<Orders>().HasOne(u => u.User).WithMany(o => o.Order).HasForeignKey(o=>o.UserID);

			builder.Entity<Product>().HasOne(pc => pc.ProductCategory).WithMany(p => p.Products).HasForeignKey(p=>p.ProductCategoryID);

			builder.Entity<Product>().HasOne(s => s.Supplier).WithMany(p => p.Products).HasForeignKey(p => p.SupplierID);
		}
	}
}
