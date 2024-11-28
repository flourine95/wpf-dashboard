using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dashboard.ValidationRules;

public class PasswordComplexityAttribute : ValidationAttribute
{
    public PasswordComplexityAttribute()
    {
        ErrorMessage = "Password must have at least 8 characters, including uppercase, lowercase, numbers, and special characters.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;

        if (string.IsNullOrEmpty(password))
        {
            return new ValidationResult("Password cannot be empty.");
        }

        if (password.Length < 8)
        {
            return new ValidationResult("Password must have at least 8 characters.");
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return new ValidationResult("Password must contain at least one uppercase letter.");
        }

        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            return new ValidationResult("Password must contain at least one lowercase letter.");
        }

        if (!Regex.IsMatch(password, @"\d"))
        {
            return new ValidationResult("Password must contain at least one number.");
        }

        if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?\""{}|<>]"))
        {
            return new ValidationResult("Password must contain at least one special character.");
        }


        var weakPasswords = new[] { "password", "123456", "qwerty", "iloveyou", "welcome" };
        if (Array.Exists(weakPasswords, p => p.Equals(password, StringComparison.OrdinalIgnoreCase)))
        {
            return new ValidationResult("Password is too weak.");
        }

        return ValidationResult.Success;
    }
}