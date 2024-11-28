namespace DashboardManager.Models;

public class Order
{
    public int OrderId { get; set; } // PK
    public byte Status { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public int UserId { get; set; } // FK
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User User { get; set; } = null!;
}