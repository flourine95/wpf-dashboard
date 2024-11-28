using System.Windows;
using WPFEntity.ViewModels;

namespace WPFEntity;


public partial class MainWindow : Window
{
    private readonly UserViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new UserViewModel();
        DataContext = _viewModel;
    }

   
}