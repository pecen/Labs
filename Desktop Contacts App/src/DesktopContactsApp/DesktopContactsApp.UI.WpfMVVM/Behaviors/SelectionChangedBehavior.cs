using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.UI.WpfMVVM.Models;
using DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels;
using DesktopContactsApp.UI.WpfMVVM.MVVM.Views;
using Microsoft.Xaml.Behaviors;
using SQLite;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfMVVM.Behaviors
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
                                return;
                            }

                            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                            {
                                connection.CreateTable<Contact>();
                                connection.Update(vm.Contact);
                            }

                            if (dialogWindow.DialogResult == true)
                            {
                                var mainWindowVm = mainWindow.DataContext as MainWindowViewModel;
                                mainWindowVm.ReadDatabase();
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
