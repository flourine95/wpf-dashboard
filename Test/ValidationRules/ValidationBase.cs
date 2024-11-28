using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Test.ValidationRules;

public abstract class ValidationBase<T> : IDataErrorInfo, INotifyPropertyChanged where T : class
{
    protected readonly T _validationModel;

    protected ValidationBase(T validationModel)
    {
        _validationModel = validationModel;
    }

    public string this[string columnName] => ValidateProperty(columnName);

    private string ValidateProperty(string columnName)
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(_validationModel) { MemberName = columnName };
        Validator.TryValidateProperty(
            _validationModel.GetType().GetProperty(columnName)?.GetValue(_validationModel),
            context,
            validationResults
        );

        return validationResults.FirstOrDefault()?.ErrorMessage ?? string.Empty;
    }

    public string Error => ValidateObject();

    private string ValidateObject()
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(_validationModel);
        Validator.TryValidateObject(_validationModel, context, validationResults, true);
        return validationResults.FirstOrDefault()?.ErrorMessage ?? string.Empty;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}