using System.ComponentModel.DataAnnotations;
using Dashboard.ValidationRules;

namespace Dashboard.Models;

public class User
{
    [Key] public int Id { get; set; }

    [MaxLength(254, ErrorMessage = "Email must not exceed 254 characters")]
    [Required(ErrorMessage = "Email must not be empty")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string Email { get; set; }

    [PasswordComplexity(ErrorMessage = "Password is invalid.")]
    public string Password { get; set; }

    [MaxLength(20, ErrorMessage = "Fullname must not exceed 20 characters")]
    [Required(ErrorMessage = "Fullname must not be empty")]
    public string Fullname { get; set; }

    [MaxLength(20, ErrorMessage = "Phone number must not exceed 20 characters")]
    [Required(ErrorMessage = "Phone number must not be empty")]
    public string Phone { get; set; }

    public int Role { get; set; }

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email},Password: {Password}, Fullname: {Fullname}, Phone: {Phone}, Role: {Role}, Status: {Status}";
        
    }
}