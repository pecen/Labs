using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.UI.WpfMVVM.Models;
using DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels;
using DesktopContactsApp.UI.WpfMVVM.MVVM.Views;
using Microsoft.Xaml.Behaviors;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfMVVM.Behaviors
{
    public class NewContactBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObjectClick;
        }

        private void AssociatedObjectClick(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is Button associatedButton)
            {
                var mainWindow = associatedButton.FindParent<MainWindow>();

                if (mainWindow != null)
                {
                    NewContactWindow newContactWindow = new NewContactWindow();
                    newContactWindow.ShowDialog();

                    if (newContactWindow.DialogResult == true)
                    {
                        mainWindow.GetViewModel<MainWindowViewModel>().ReadDatabase();
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObjectClick;
            base.OnDetaching();
        }
    }
}
