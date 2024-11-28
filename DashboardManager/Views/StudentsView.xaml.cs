using System.Windows.Controls;
using DashboardManager.ViewModels;

namespace DashboardManager.Views;

public partial class StudentsView : UserControl
{
    public StudentsView()
    {
        InitializeComponent();
        // DataContext = new StudentViewModel();
    }
}