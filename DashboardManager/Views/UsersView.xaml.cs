﻿using System.Windows.Controls;

namespace DashboardManager.Views;

public partial class UsersView : UserControl
{
    public UsersView()
    {
        InitializeComponent();
        DataContext = this;
    }
}