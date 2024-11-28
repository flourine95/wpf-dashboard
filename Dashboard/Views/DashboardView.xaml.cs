using System.Windows;
using System.Windows.Controls;
using Dashboard.Utilities;
using Dashboard.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Views;

public partial class DashboardView : Window
{
    private DashboardViewModel _viewModel;

    public DashboardView(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _viewModel = new DashboardViewModel(serviceProvider);
        DataContext = _viewModel;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            var selectedItem = (NavigationItem)((ListBox)sender).SelectedItem;
            _viewModel.OnListBoxSelectionChanged(selectedItem);
            MainContentControl.Content = _viewModel.SelectedUserControl;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("tinh nang chua phat trien");
    }
}