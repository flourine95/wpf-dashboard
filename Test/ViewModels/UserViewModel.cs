using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Test.Commands;
using Test.Models;
using Test.ValidationRules;

namespace Test.ViewModels;

public class UserViewModel :  ValidationBase<User>
{
    private User _user;

    public UserViewModel() : base(new User())
    {
        _user = _validationModel;
        SaveCommand = new RelayCommand(Save, CanSave);
        CancelCommand = new RelayCommand(Cancel);
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public string Name
    {
        get => _user.Name;
        set
        {
            if (_user.Name != value)
            {
                _user.Name = value;
                OnPropertyChanged(); // Thông báo thay đổi cho thuộc tính Name
                OnPropertyChanged(nameof(User)); // Thông báo thay đổi cho đối tượng User
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged(); // Cập nhật trạng thái nút Save
            }
        }
    }

    public string Email
    {
        get => _user.Email;
        set
        {
            if (_user.Email != value)
            {
                _user.Email = value;
                OnPropertyChanged(); // Thông báo thay đổi cho thuộc tính Email
                OnPropertyChanged(nameof(User)); // Thông báo thay đổi cho đối tượng User
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged(); // Cập nhật trạng thái nút Save
            }
        }
    }

    public string Password
    {
        get => _user.Password;
        set
        {
            if (_user.Password != value)
            {
                _user.Password = value;
                OnPropertyChanged(); // Thông báo thay đổi cho thuộc tính Password
                OnPropertyChanged(nameof(User)); // Thông báo thay đổi cho đối tượng User
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged(); // Cập nhật trạng thái nút Save
            }
        }
    }

    private void Save()
    {
        // Logic để lưu dữ liệu
    }

    private bool CanSave() => string.IsNullOrEmpty(Error);

    private void Cancel()
    {
        // Logic để thoát hoặc hủy bỏ
    }
}