using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using DashboardManager.Commands;
using DashboardManager.Models;
using DashboardManager.Services;

namespace DashboardManager.ViewModels;

public class ProductViewModel : BaseViewModel
{
    private readonly IService<Product> _service;
    private ObservableCollection<Product> _products;
    private Product _selectedProduct;
    private int _currentPage = 1;
    private const int PageSize = 10;

    public ObservableCollection<Product> Products
    {
        get => _products;
        set => SetField(ref _products, value);
    }

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set => SetField(ref _selectedProduct, value);
    }


    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ImportCommand { get; }
    public ICommand ExportCommand { get; }
    public ICommand NextPageCommand { get; }
    public ICommand PreviousPageCommand { get; }
    public ICommand SortCommand { get; }

    public ProductViewModel(IService<Product> service)
    {
        _service = service;
        Products = new ObservableCollection<Product>();
        LoadProducts();

        AddCommand = new RelayCommand(Add);
        UpdateCommand = new RelayCommand(Update);
        DeleteCommand = new RelayCommand(Delete);
        ImportCommand = new RelayCommand(Import);
        ExportCommand = new RelayCommand(Export);
        NextPageCommand = new RelayCommand(NextPage);
        PreviousPageCommand = new RelayCommand(PreviousPage);
        SortCommand = new RelayCommand<string>(Sort);
    }

    private void LoadProducts()
    {
        var products = _service.GetPaged(_currentPage, PageSize);
        Products = new ObservableCollection<Product>(products);
    }

    private void Add()
    {
        if (SelectedProduct != null)
        {
            _service.Add(SelectedProduct);
            LoadProducts();
        }
    }

    private void Update()
    {
        if (SelectedProduct != null)
        {
            _service.Update(SelectedProduct);
            LoadProducts();
        }
    }

    private void Delete()
    {
        if (SelectedProduct != null)
        {
            _service.Delete(SelectedProduct);
            LoadProducts();
        }
    }

    private void Import()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Excel Files|*.xlsx|CSV Files|*.csv",
            Title = "Chọn file để import"
        };

        try
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileExtension = Path.GetExtension(dialog.FileName).ToLower();
                if (fileExtension != ".xlsx" && fileExtension != ".csv")
                {
                    MessageBox.Show("Vui lòng chọn file Excel hoặc CSV");
                    return;
                }

                _service.ImportFromExcel(dialog.FileName);
                LoadProducts();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi import: {ex.Message}");
        }
    }

    private void Export()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Files|*.xlsx|CSV Files|*.csv",
            Title = "Lưu file export"
        };

        try
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _service.ExportToExcel(dialog.FileName);
                MessageBox.Show("Export thành công!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi export: {ex.Message}");
        }
    }

    private void NextPage()
    {
        _currentPage++;
        LoadProducts();
    }

    private void PreviousPage()
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            LoadProducts();
        }
    }

    private void Sort(string propertyName)
    {
        var products = _service.Sort(propertyName);
        Products = new ObservableCollection<Product>(products);
    }
}