namespace DashboardManager.Models;

public class Post
{
    public int PostId { get; set; } // PK
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public byte Status { get; set; }
    public int UserId { get; set; } // FK
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User User { get; set; } = null!;
}