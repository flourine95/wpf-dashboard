using System.Windows;
using Test.ViewModels;

namespace Test.Views;

public partial class UserView : Window
{
    public UserView()
    {
        InitializeComponent();
        DataContext = new UserViewModel();
    }
}