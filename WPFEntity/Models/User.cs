using System.ComponentModel.DataAnnotations;

namespace WPFEntity.Models;

public class User
{
    public int Id { get; init; }
    [StringLength(100)] public required string Name { get; set; }
    [StringLength(200)] public required string Email { get; set; }
    [StringLength(200)] public required string Password { get; set; }
    // role: 0 = User, 1 = Admin
    public int Role { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}