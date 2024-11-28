using MaterialDesignThemes.Wpf;

namespace Dashboard.Utilities;

public class NavigationItem
{
    public string Title { get; set; }
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }
}