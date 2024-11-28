using MaterialDesignThemes.Wpf;

namespace DashboardManager.Models;

public class NavigationItem
{
    public string Title { get; set; }
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }
}