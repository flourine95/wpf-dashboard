using System.Windows;
using System.Windows.Controls;
using Dashboard.Utilities;
using Dashboard.Views;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    public List<NavigationItem> NavigationItems { get; set; }
    private readonly IServiceProvider _serviceProvider;
    private UserControl? _selectedUserControl;

    public UserControl? SelectedUserControl
    {
        get => _selectedUserControl;
        set
        {
            _selectedUserControl = value;
            OnPropertyChanged();
        }
    }

    public DashboardViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        NavigationItems = new List<NavigationItem>
        {
            new()
            {
                Title = "Users",
                SelectedIcon = PackIconKind.AccountGroup,
                UnselectedIcon = PackIconKind.AccountGroupOutline,
            },

            new()
            {
                Title = "Products",
                SelectedIcon = PackIconKind.PackageVariant,
                UnselectedIcon = PackIconKind.PackageVariantClosed,
            },

            new()
            {
                Title = "Orders",
                SelectedIcon = PackIconKind.Cart,
                UnselectedIcon = PackIconKind.CartOutline,
            },

            new()
            {
                Title = "Categories",
                SelectedIcon = PackIconKind.Tag,
                UnselectedIcon = PackIconKind.TagOutline,
            },

            new()
            {
                Title = "Brands",
                SelectedIcon = PackIconKind.Flag,
                UnselectedIcon = PackIconKind.FlagOutline,
            },

            new()
            {
                Title = "Feedbacks",
                SelectedIcon = PackIconKind.Comment,
                UnselectedIcon = PackIconKind.CommentOutline,
            },
            new()
            {
                Title = "Posts",
                SelectedIcon = PackIconKind.Post,
                UnselectedIcon = PackIconKind.PostOutline,
            },
            new()
            {
                Title = "Others",
                SelectedIcon = PackIconKind.Cog,
                UnselectedIcon = PackIconKind.CogOutline,
            },
        };
    }

    public void OnListBoxSelectionChanged(NavigationItem selectedItem)
    {
        SelectedUserControl = selectedItem?.Title switch
        {
            "Users" => _serviceProvider.GetRequiredService<UsersView>(),
            "Products" => _serviceProvider.GetRequiredService<ProductsView>(),
            // ... các trường hợp khác ...
            _ => null
        };

        if (SelectedUserControl == null)
        {
            MessageBox.Show("Chức năng này chưa được phát triển", "Thông báo",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}