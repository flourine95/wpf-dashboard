using System.Windows;
using System.Windows.Controls;
using Dashboard.ViewModels;

namespace Dashboard.Views;

public partial class CreateUserView : Window
{
    public CreateUserView(CreateUserViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel; 
    }

}