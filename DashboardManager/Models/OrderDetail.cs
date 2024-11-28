namespace DashboardManager.Models;

public class OrderDetail
{
    public int OrderDetailId { get; set; } // PK
    public int ProductId { get; set; } // FK
    public int OrderId { get; set; } // FK
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}