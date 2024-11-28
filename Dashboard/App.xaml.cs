using System.Windows;
using Dashboard.Data;
using Dashboard.Services;
using Dashboard.ViewModels;
using Dashboard.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

    
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        // Preload data
        var userService = _serviceProvider.GetRequiredService<UserService>();
        await userService.GetAllUsers();

        var dashboardView = _serviceProvider.GetRequiredService<DashboardView>();
        dashboardView.Show();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Đăng ký DbContext là Singleton
        services.AddDbContext<AppDbContext>(
            options => options.UseMySql(
                "server=localhost;database=dashboard;user=root;password=",
                ServerVersion.AutoDetect("server=localhost;database=dashboard;user=root;password=")
            ),
            ServiceLifetime.Singleton
        );

        services.AddSingleton<UserService>();
        services.AddTransient<UserViewModel>();
        // Views
        services.AddSingleton<DashboardView>();
        services.AddTransient<UsersView>(); 
        services.AddTransient<ProductsView>();
        services.AddTransient<CreateUserView>();
        
        
        
        
        
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }

        base.OnExit(e);
    }
}