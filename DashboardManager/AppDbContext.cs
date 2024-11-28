using DashboardManager.Models;
using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext

{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Grade> Grades { get; set; }
    public DbSet<Student> Students { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(local);Database=dashboard_manager;Uid=sa;Pwd=long1032002;Trusted_Connection=True;Trust Server Certificate=True"); // Hoặc UseSqlServer cho SQL Server
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<Product>()
            .Property(p => p.OldPrice)
            .HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<OrderDetail>()
            .Property(od => od.Price)
            .HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<Order>()
            .Property(o => o.Total)
            .HasColumnType("decimal(10, 2)");
        
        
        SeedUsers(modelBuilder);
        SeedProducts(modelBuilder);
        SeedOrders(modelBuilder);
        SeedCategories(modelBuilder);
        SeedBrands(modelBuilder);
        SeedFeedbacks(modelBuilder);
        SeedOrderDetails(modelBuilder);
    }

    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1, Email = "admin@example.com", Password = "hashed_password", FullName = "Admin User",
                Role = 1, ProvinceId = "01", DistrictId = "001", WardId = "0001", Address = "123 Admin St",
                Birthday = new DateTime(1990, 1, 1), Description = "Administrator", Ip = "192.168.1.1",
                UserAgent = "Mozilla/5.0", Avatar = "avatar1.png", Phone = "0123456789", EmailVerifiedAt = DateTime.Now,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new User
            {
                UserId = 2, Email = "user@example.com", Password = "hashed_password", FullName = "Normal User",
                Role = 0, ProvinceId = "02", DistrictId = "002", WardId = "0002", Address = "456 User St",
                Birthday = new DateTime(1995, 5, 5), Description = "Regular user", Ip = "192.168.1.2",
                UserAgent = "Mozilla/5.0", Avatar = "avatar2.png", Phone = "0987654321", EmailVerifiedAt = DateTime.Now,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            }
        );
    }

    public static void SeedProducts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1, Name = "Product 1", Price = 99.99m, OldPrice = 120.00m, Images = "product1.jpg",
                Description = "Description for Product 1", Specification = "Specs for Product 1", PurchaseCount = 100,
                Quantity = 10, BrandId = 1, CategoryId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new Product
            {
                ProductId = 2, Name = "Product 2", Price = 49.99m, OldPrice = 70.00m, Images = "product2.jpg",
                Description = "Description for Product 2", Specification = "Specs for Product 2", PurchaseCount = 200,
                Quantity = 20, BrandId = 2, CategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            }
        );
    }

    public static void SeedOrders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1, Status = 1, Note = "Urgent delivery", Total = 149.98m, UserId = 1,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new Order
            {
                OrderId = 2, Status = 0, Note = "Regular delivery", Total = 49.99m, UserId = 2,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            }
        );
    }

    public static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Electronics", Images = "electronics.jpg" },
            new Category { CategoryId = 2, Name = "Clothing", Images = "clothing.jpg" }
        );
    }

    public static void SeedBrands(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().HasData(
            new Brand { BrandId = 1, Name = "Brand A", Images = "brandA.jpg" },
            new Brand { BrandId = 2, Name = "Brand B", Images = "brandB.jpg" }
        );
    }

    public static void SeedFeedbacks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>().HasData(
            new Feedback
            {
                FeedbackId = 1, Star = 5, Content = "Excellent product!", Status = 1, ProductId = 1, UserId = 1,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            },
            new Feedback
            {
                FeedbackId = 2, Star = 4, Content = "Good value for money.", Status = 1, ProductId = 2, UserId = 2,
                CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
            }
        );
    }

    public static void SeedOrderDetails(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail
            {
                OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 99.99m, CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderDetail
            {
                OrderDetailId = 2, OrderId = 1, ProductId = 2, Quantity = 1, Price = 49.99m, CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new OrderDetail
            {
                OrderDetailId = 3, OrderId = 2, ProductId = 2, Quantity = 1, Price = 49.99m, CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        );
    }
}