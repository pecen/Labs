﻿using System.Windows;

namespace DesktopContactsApp.UI.WpfMVVM.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
        }
    }
}
