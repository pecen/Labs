using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.Services;
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
        private readonly IDialogService _dialogService = new DialogService();

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObjectSelectionChanged;
        }

        private void AssociatedObjectSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is ListView associatedListView)
            {
                var selectedContact = (Contact) associatedListView.SelectedItem;

                if (selectedContact != null)
                {
                    var vm = new ContactDetailsWindowViewModel
                    {
                        Id = selectedContact.Id,
                        Name = selectedContact.Name,
                        Email = selectedContact.Email,
                        Phone = selectedContact.Phone,
                        IsDirty = false
                    };

                    _dialogService.ShowDialog<ContactDetailsWindowViewModel>(result => 
                    {
                        var dialogResult = result;

                        //if(dialogResult != null)
                        //{
                        //    associatedListView.GetViewModel<MainWindowViewModel>().ReadDatabase();
                        //}
                    }, 
                    vm);
                }

                //var mainWindow = associatedListView.FindParent<MainWindow>();

                //if (mainWindow != null)
                //{
                //    Contact selectedContact = (Contact)mainWindow.contactsListView.SelectedItem;

                //    if (selectedContact != null)
                //    {
                //        DialogService dialogService = new DialogService();

                //        dialogService.ShowDialog<ContactDetailsWindowViewModel>(result =>
                //        {
                //            var test = result;
                //        });

                //        //ContactDetailsWindow dialogWindow = new ContactDetailsWindow(); // selectedContact);

                //        //if (dialogWindow.DataContext is ContactDetailsWindowViewModel vm)
                //        //{
                //        //    vm.Id = selectedContact.Id;
                //        //    vm.Name = selectedContact.Name;
                //        //    vm.Email = selectedContact.Email;
                //        //    vm.Phone = selectedContact.Phone;

                //        //    vm.IsDirty = false;

                //        //    dialogWindow.ShowDialog();

                //        //    if (!vm.IsDirty)
                //        //    {
                //        //        associatedListView.SelectedItem = null;
                //        //        return;
                //        //    }

                //        //    if (dialogWindow.DialogResult == true)
                //        //    {
                //        //        mainWindow.GetViewModel<MainWindowViewModel>().ReadDatabase();
                //        //    }
                //        //}
                //    }
                //}
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObjectSelectionChanged;
            base.OnDetaching();
        }
    }
}
