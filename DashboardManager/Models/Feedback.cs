namespace DashboardManager.Models;

public class Feedback
{
    public int FeedbackId { get; set; } // PK
    public byte Star { get; set; }
    public string Content { get; set; } = string.Empty;
    public byte Status { get; set; }
    public int ProductId { get; set; } // FK
    public int UserId { get; set; } // FK
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Product Product { get; set; } = null!;
    public User User { get; set; } = null!;
}