using DesktopContactsApp.UI.Wpf.Models;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Core.Extensions;

namespace DesktopContactsApp.UI.Wpf.Behaviors
{
    public class SelectionChangedBehavior : Behavior<ListView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObjectSelectionChanged;
        }

        private void AssociatedObjectSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is ListView associatedListView)
            {
                var mainWindow = associatedListView.FindParent<MainWindow>();

                if (mainWindow != null)
                {
                    Contact selectedContact = (Contact)mainWindow.contactsListView.SelectedItem;

                    if (selectedContact != null)
                    {
                        ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                        contactDetailsWindow.ShowDialog();

                        if (contactDetailsWindow.DialogResult == true)
                        {
                            associatedListView.Items.Refresh();
                        }
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObjectSelectionChanged;
            base.OnDetaching();
        }
    }
}
