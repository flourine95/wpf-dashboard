using System.Windows;
using System.Windows.Controls;
using Dashboard.ViewModels;
using MaterialDesignThemes.Wpf;

namespace Dashboard.Views;

public partial class UsersView : UserControl
{
    private readonly UserViewModel _viewModel;

    public UsersView(UserViewModel viewModel) // Constructor Injection
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }


}