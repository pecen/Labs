using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.UI.WpfService.Models;
using DesktopContactsApp.UI.WpfService.MVVM.ViewModels;
using DesktopContactsApp.UI.WpfService.MVVM.Views;
using Microsoft.Xaml.Behaviors;
using SQLite;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfService.Behaviors
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
                        ContactDetailsWindow dialogWindow = new ContactDetailsWindow(); // selectedContact);

                        if (dialogWindow.DataContext is ContactDetailsWindowViewModel vm)
                        {
                            vm.Id = selectedContact.Id;
                            vm.Name = selectedContact.Name;
                            vm.Email = selectedContact.Email;
                            vm.Phone = selectedContact.Phone;

                            vm.IsDirty = false;

                            dialogWindow.ShowDialog();

                            if (!vm.IsDirty)
                            {
                                associatedListView.SelectedItem = null;
                                return;
                            }

                            if (dialogWindow.DialogResult == true)
                            {
                                mainWindow.GetViewModel<MainWindowViewModel>().ReadDatabase();
                            }
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
