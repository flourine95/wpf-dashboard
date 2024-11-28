using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Dashboard.Models;
using Dashboard.Services;
using Dashboard.Utilities;
using Dashboard.Views;
using Microsoft.Win32;
using OfficeOpenXml;

namespace Dashboard.ViewModels;

public class UserViewModel : BaseViewModel
{
    private readonly UserService _userService;
    private ObservableCollection<User> _users;
    public ICommand ImportCommand { get; set; }
    public ICommand ExportCommand { get; set; }
    public ICommand CreateCommand { get; set; }

    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set => SetField(ref _isLoading, value);
    }


    public ObservableCollection<User> Users
    {
        get => _users;
        set => SetField(ref _users, value);
    }

    public UserViewModel(UserService userService)
    {
        _userService = userService;
        Users = new ObservableCollection<User>();
        ImportCommand = new RelayCommand(async _ => await ImportExcel());
        ExportCommand = new RelayCommand(async _ => await ExportExcel());
        CreateCommand = new RelayCommand(async _ => await CreateUser());
        LoadUsers();
    }

    private Task CreateUser()
    {
        var createUserViewModel = new CreateUserViewModel(_userService); 
        var createUserView = new CreateUserView(createUserViewModel);

        createUserView.ShowDialog();
        return Task.CompletedTask;
    }

    private async Task ImportExcel()
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Excel Files|*.xlsx;*.xls",
            Title = "Select an Excel File"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            using (var package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
            {
                var worksheet = package.Workbook.Worksheets[0]; 
                int rowCount = worksheet.Dimension.Rows; 

                for (int row = 2; row <= rowCount; row++)
                {
                    var newUser = new User
                    {
                        Fullname = worksheet.Cells[row, 2].Text,
                        Email = worksheet.Cells[row, 3].Text,
                        Password = worksheet.Cells[row, 4].Text,
                        Phone = worksheet.Cells[row, 5].Text,
                    };

                    try
                    {
                        await _userService.AddUserAsync(newUser); 
                        Users.Add(newUser); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing user: {ex.Message}", "Error", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }
    }

    private async Task ExportExcel()
    {
        var saveFileDialog = new SaveFileDialog
        {
            Filter = "Excel Files|*.xlsx",
            Title = "Save an Excel File"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Users");

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fullname";
                worksheet.Cells[1, 3].Value = "Email";
                worksheet.Cells[1, 4].Value = "Password";
                worksheet.Cells[1, 5].Value = "Phone";
                worksheet.Cells[1, 6].Value = "Role";
                worksheet.Cells[1, 7].Value = "Created At";
                worksheet.Cells[1, 8].Value = "Updated At";

                int row = 2;
                foreach (var user in Users)
                {
                    worksheet.Cells[row, 1].Value = user.Id;
                    worksheet.Cells[row, 2].Value = user.Fullname;
                    worksheet.Cells[row, 3].Value = user.Email;
                    worksheet.Cells[row, 4].Value = user.Password;
                    worksheet.Cells[row, 5].Value = user.Phone;
                    worksheet.Cells[row, 6].Value = user.Role;
                    worksheet.Cells[row, 7].Value = user.CreatedAt.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 8].Value = user.UpdatedAt.ToString("yyyy-MM-dd");
                    row++;
                }

                // Lưu file
                var file = new FileInfo(saveFileDialog.FileName);
                await package.SaveAsAsync(file);
            }
        }
    }


    private async void LoadUsers()
    {
        try
        {
            IsLoading = true;
            var users = await _userService.GetAllUsers();
            Debug.WriteLine(users.Count);
            Users = new ObservableCollection<User>(users);
            Debug.WriteLine(Users.Count);
        }
     
        finally
        {
            IsLoading = false;
        }
    }
}