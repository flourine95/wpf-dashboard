using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Dashboard.Models;
using Dashboard.Services;

namespace Dashboard.ViewModels;

public class CreateUserViewModel : IDataErrorInfo, INotifyPropertyChanged
{
    private UserService _userService;
    private string _fullname;
    private string _email;
    private string _phone;
    private string _password;
    public ICommand CancelCommand { get; set; }
    public ICommand SaveCommand { get; set; }

    public CreateUserViewModel(UserService userService)
    {
        _userService = userService;
        CancelCommand = new RelayCommand(Cancel);
        SaveCommand = new RelayCommand(async _ => await SaveAsync(), CanSave);
    }

    private async Task SaveAsync()
    {
        try
        {
            var user = new User
            {
                Fullname = _fullname,
                Email = _email,
                Phone = _phone,
                Password = _password
            };
            Debug.WriteLine(user.ToString());
            var isOk = await _userService.AddUserAsync(user);
            if (isOk)
            {
                MessageBox.Show("New user has been added successfully", "Notification", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("An error occurred while adding new user", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            ClearUserInput();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error creating new user: " + ex.Message);
            MessageBox.Show("Error creating new user: " + ex.Message, "Error", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    private Task Cancel(object arg)
    {
        var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo,
            MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            ClearUserInput();
            Application.Current.Windows[1].Close();
        }

        return Task.FromResult(Task.CompletedTask);
    }

    private void ClearUserInput()
    {
        Fullname = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Password = string.Empty;
    }


    private bool CanSave(object obj)
    {
        return string.IsNullOrEmpty(this[nameof(Fullname)]) &&
               string.IsNullOrEmpty(this[nameof(Email)]) &&
               string.IsNullOrEmpty(this[nameof(Phone)]) &&
               string.IsNullOrEmpty(this[nameof(Password)]);
    }


    public string Fullname
    {
        get => _fullname;
        set
        {
            _fullname = value;
            OnPropertyChanged(nameof(Fullname));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public string Error => string.Empty;

    public string this[string columnName]
    {
        get
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(new User()) { MemberName = columnName };

            var value = GetType().GetProperty(columnName)?.GetValue(this);

            if (!Validator.TryValidateProperty(value, context, validationResults))
            {
                return validationResults.FirstOrDefault()?.ErrorMessage ?? string.Empty;
            }

            return string.Empty;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }
}