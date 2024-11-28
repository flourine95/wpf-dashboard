using System.Globalization;
using System.Windows.Controls;

namespace Dashboard.ValidationRules;

public class NotEmptyValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult(false, "This field cannot be empty.");
        }
        return ValidationResult.ValidResult;
    }
}