using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPFEntity.Models;
using WPFEntity.Utilities;


namespace WPFEntity.ViewModels;

public class UserViewModel : BaseViewModel
{
    private readonly AppDbContext _context;

    public ICommand CreateCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand SearchCommand { get; }

    public ObservableCollection<User> Users { get; set; } = new();
    public ICollectionView UsersView { get; private set; }

    private string _searchKeyword;

    public string SearchKeyword
    {
        get => _searchKeyword;
        set
        {
            _searchKeyword = value;
            OnPropertyChanged();
            UsersView.Refresh(); // Làm mới danh sách khi từ khóa thay đổi
        }
    }

    public UserViewModel()
    {
        _context = new AppDbContext();
        LoadUsers();

        CreateCommand = new RelayCommand(OnCreate);
        UpdateCommand = new RelayCommand(OnUpdate, CanExecuteUpdateDelete);
        DeleteCommand = new RelayCommand(OnDelete, CanExecuteUpdateDelete);
        SearchCommand = new RelayCommand(OnSearch);

        // Khởi tạo CollectionView và thêm bộ lọc
        UsersView = CollectionViewSource.GetDefaultView(Users);
        UsersView.Filter = FilterUsers;
    }

    private void OnCreate(object parameter)
    {
        var newUser = new User
        {
            Name = "New User",
            Email = "newuser@example.com",
            Password = "password",
            Role = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();
        LoadUsers();
    }

    private void OnUpdate(object parameter)
    {
        if (parameter is not User user) return;
        user.Name = "Updated Name";
        _context.SaveChanges();
        LoadUsers();
    }

    private void OnDelete(object parameter)
    {
        if (parameter is not User user) return;
        _context.Users.Remove(user);
        _context.SaveChanges();
        LoadUsers();
    }

    private bool CanExecuteUpdateDelete(object parameter)
    {
        return parameter is User;
    }

    private void LoadUsers()
    {
        var users = _context.Users.ToList();
        Users.Clear();
        foreach (var user in users)
        {
            Users.Add(user);
        }

        // Làm mới lại CollectionView sau khi tải dữ liệu
        UsersView?.Refresh();
    }

    private void OnSearch(object parameter)
    {
        UsersView.Refresh(); // Làm mới bộ lọc khi nhấn nút Search
    }

    private bool FilterUsers(object obj)
    {
        if (obj is not User user) return false;

        if (string.IsNullOrWhiteSpace(SearchKeyword)) return true;

        var keyword = SearchKeyword.ToLower();
        return user.Name.ToLower().Contains(keyword) ||
               user.Email.ToLower().Contains(keyword) ||
               user.Role.ToString().Contains(keyword);
    }
}