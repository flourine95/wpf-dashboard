using System.Windows;
using System.Windows.Controls;
using DashboardManager.Models;
using MaterialDesignThemes.Wpf;

namespace DashboardManager.Views;

public partial class DashboardView : Window
{
    public List<NavigationItem> NavigationItems { get; set; }
    public object? SelectedUserControl { get; set; }


    public DashboardView()
    {
        InitializeComponent();
        DataContext = this;
        NavigationItems =
        [
            new NavigationItem
            {
                Title = "Users",
                SelectedIcon = PackIconKind.AccountGroup,
                UnselectedIcon = PackIconKind.AccountGroupOutline,
            },

            new NavigationItem
            {
                Title = "Products",
                SelectedIcon = PackIconKind.PackageVariant,
                UnselectedIcon = PackIconKind.PackageVariantClosed,
            },

            new NavigationItem
            {
                Title = "Orders",
                SelectedIcon = PackIconKind.Cart,
                UnselectedIcon = PackIconKind.CartOutline,
            },

            new NavigationItem
            {
                Title = "Categories",
                SelectedIcon = PackIconKind.Tag,
                UnselectedIcon = PackIconKind.TagOutline,
            },

            new NavigationItem
            {
                Title = "Brands",
                SelectedIcon = PackIconKind.Flag,
                UnselectedIcon = PackIconKind.FlagOutline,
            },

            new NavigationItem
            {
                Title = "Feedbacks",
                SelectedIcon = PackIconKind.Comment,
                UnselectedIcon = PackIconKind.CommentOutline,
            },
            new NavigationItem
            {
                Title = "Posts",
                SelectedIcon = PackIconKind.Post,
                UnselectedIcon = PackIconKind.PostOutline,
            },
            new NavigationItem
            {
                Title = "Others",
                SelectedIcon = PackIconKind.Cog,
                UnselectedIcon = PackIconKind.CogOutline,
            },
        ];
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Hello");
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Lấy item được chọn từ ListBox
        var selectedItem = (NavigationItem)((ListBox)sender).SelectedItem;

        // Kiểm tra nếu item là "Users" và gán UserControl tương ứng
        SelectedUserControl = selectedItem?.Title switch
        {
            "Users" => new UsersView(),
            "Products" => new ProductsView(),
            "Orders" => new OrdersView(),
            "Categories" => new CategoriesView(),
            "Brands" => new BrandsView(),
            "Feedbacks" => new FeedbacksView(),
            "Posts" => new PostsView(),
            "Others" => new OthersView(),
            _ => MessageBox.Show("Nothing to show"),
        };

        MainContentControl.Content = SelectedUserControl;
    }
}