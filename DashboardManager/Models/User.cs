namespace DashboardManager.Models;

public class User
{
    public int UserId { get; set; } // PK
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public byte Role { get; set; } = 0;
    public string? ProvinceId { get; set; }
    public string? DistrictId { get; set; }
    public string? WardId { get; set; }
    public string? Address { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Description { get; set; }
    public string? Ip { get; set; }
    public string? UserAgent { get; set; }
    public string? Avatar { get; set; }
    public string? Phone { get; set; }
    public DateTime? EmailVerifiedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}