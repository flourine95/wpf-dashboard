using System.Windows.Controls;
using DashboardManager.Repositories;
using DashboardManager.Services;
using DashboardManager.ViewModels;

namespace DashboardManager.Views;

public partial class ProductsView : UserControl
{
    public ProductsView()
    {
        InitializeComponent();
        var productRepository = new ProductRepository(new AppDbContext());
        var productService = new ProductService(productRepository);
        DataContext = new ProductViewModel(productService);
        
    }
}