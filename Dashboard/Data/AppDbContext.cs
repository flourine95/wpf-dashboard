using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ward> Wards { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseMySql("server=localhost;database=dashboard;user=root;password=;",
    //         new MySqlServerVersion(new Version(8, 0, 21)));
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

         // Mapping bảng Brand
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(b => b.Id).HasColumnName("id");
            entity.Property(b => b.Name).HasColumnName("name");
            entity.Property(b => b.Description).HasColumnName("description");
            entity.Property(b => b.Image).HasColumnName("image");
            entity.Property(b => b.CreatedAt).HasColumnName("created_at");
            entity.Property(b => b.UpdatedAt).HasColumnName("updated_at");
        });

        // Mapping bảng Category
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.Id).HasColumnName("id");
            entity.Property(c => c.Name).HasColumnName("name");
            entity.Property(c => c.Description).HasColumnName("description");
            entity.Property(c => c.CreatedAt).HasColumnName("created_at");
            entity.Property(c => c.UpdatedAt).HasColumnName("updated_at");
        });

        // Mapping bảng District
        modelBuilder.Entity<District>(entity =>
        {
            entity.Property(d => d.Id).HasColumnName("id");
            entity.Property(d => d.Name).HasColumnName("name");
            entity.Property(d => d.ProvinceId).HasColumnName("province_id");
        });

        // Mapping bảng Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(o => o.Id).HasColumnName("id");
            entity.Property(o => o.UserId).HasColumnName("user_id");
            entity.Property(o => o.TotalAmount).HasColumnName("total_amount");
            entity.Property(o => o.OrderDate).HasColumnName("order_date");
            entity.Property(o => o.Status).HasColumnName("status");
            entity.Property(o => o.Address).HasColumnName("address");
            entity.Property(o => o.ProvinceId).HasColumnName("province_id");
            entity.Property(o => o.DistrictId).HasColumnName("district_id");
            entity.Property(o => o.WardId).HasColumnName("ward_id");
            entity.Property(o => o.CreatedAt).HasColumnName("created_at");
            entity.Property(o => o.UpdatedAt).HasColumnName("updated_at");
        });

        // Mapping bảng OrderItem
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(oi => oi.Id).HasColumnName("id");
            entity.Property(oi => oi.OrderId).HasColumnName("order_id");
            entity.Property(oi => oi.ProductId).HasColumnName("product_id");
            entity.Property(oi => oi.Quantity).HasColumnName("quantity");
            entity.Property(oi => oi.Price).HasColumnName("price");
            entity.Property(oi => oi.CreatedAt).HasColumnName("created_at");
            entity.Property(oi => oi.UpdatedAt).HasColumnName("updated_at");
        });

        // Mapping bảng Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Id).HasColumnName("id");
            entity.Property(p => p.Name).HasColumnName("name");
            entity.Property(p => p.Description).HasColumnName("description");
            entity.Property(p => p.Price).HasColumnName("price");
            entity.Property(p => p.Stock).HasColumnName("stock");
            entity.Property(p => p.View).HasColumnName("view");
            entity.Property(p => p.Image).HasColumnName("image");
            entity.Property(p => p.CategoryId).HasColumnName("category_id");
            entity.Property(p => p.BrandId).HasColumnName("brand_id");
            entity.Property(p => p.CreatedAt).HasColumnName("created_at");
            entity.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        });

        // Mapping bảng Province
        modelBuilder.Entity<Province>(entity =>
        {
            entity.Property(p => p.Id).HasColumnName("id");
            entity.Property(p => p.Name).HasColumnName("name");
        });

        // Mapping bảng User
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.Password).HasColumnName("password");
            entity.Property(u => u.Fullname).HasColumnName("fullname");
            entity.Property(u => u.Phone).HasColumnName("phone");
            entity.Property(u => u.Status).HasColumnName("status").HasDefaultValue(1);
            entity.Property(u => u.Role).HasColumnName("role").HasDefaultValue(0);
            entity.Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .ValueGeneratedOnAdd() // Thêm dòng này
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)"); // Thêm (6) để match với datetime(6)
        
            entity.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at") 
                .ValueGeneratedOnAddOrUpdate() // Thêm dòng này
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6)");
            entity.Property(u => u.DeletedAt).HasDefaultValue(null);
        });

        // Mapping bảng Ward
        modelBuilder.Entity<Ward>(entity =>
        {
            entity.Property(w => w.Id).HasColumnName("id");
            entity.Property(w => w.Name).HasColumnName("name");
            entity.Property(w => w.DistrictId).HasColumnName("district_id");
        });
    }
}