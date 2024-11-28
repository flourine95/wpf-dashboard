namespace DashboardManager.Models;

public class Product
{
    public int ProductId { get; set; } // PK
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public string Images { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Specification { get; set; } = string.Empty;
    public int PurchaseCount { get; set; }
    public int Quantity { get; set; }
    public int BrandId { get; set; } // FK
    public int CategoryId { get; set; } // FK
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Brand Brand { get; set; } = null!;
    public Category Category { get; set; } = null!;
}