using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.Services;
using DesktopContactsApp.UI.WpfService.Models;
using DesktopContactsApp.UI.WpfService.MVVM.UserControls;
using DesktopContactsApp.UI.WpfService.MVVM.Views;
using SQLite;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfService.MVVM.ViewModels
{
    public class ContactDetailsWindowViewModel : ViewModelBase
    {
        public DelegateCommand<UserControl> UpdateContactCommand { get; set; }
        public DelegateCommand<UserControl> DeleteContactCommand { get; set; }

        #region Properties

        private int _id;
        public int Id
        {
            get => _id;
            set { IsDirty = SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { IsDirty = SetProperty(ref _name, value); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { IsDirty = SetProperty(ref _email, value); }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set { IsDirty = SetProperty(ref _phone, value); }
        }

        public Contact Contact
        {
            get
            {
                return new Contact
                {
                    Id = Id,
                    Name = Name,
                    Email = Email,
                    Phone = Phone
                };
            }
        }

        public bool IsDirty { get; set; } = false;

        #endregion

        public ContactDetailsWindowViewModel()
        {
            Title = "Contact Details";

            UpdateContactCommand = new DelegateCommand<UserControl>(UpdateContact,
                o =>
                {
                    return IsDirty
                        && !string.IsNullOrEmpty(Name)
                        && !string.IsNullOrEmpty(Email)
                        && !string.IsNullOrEmpty(Phone);
                });
            //UpdateContactCommand = new DelegateCommand<UserControl>(UpdateContact, CanUpdate);
            DeleteContactCommand = new DelegateCommand<UserControl>(DeleteContact,
                o =>
                {
                    return !string.IsNullOrEmpty(Name)
                        || !string.IsNullOrEmpty(Email)
                        || !string.IsNullOrEmpty(Phone);
                });

            IsDirty = false;
        }

        //private bool CanUpdate(UserControl control)
        //{
        //    if (control is ContactEditControl contactEditControl)
        //    {
        //        return Name != contactEditControl.nameTextBox.Text
        //            || Email != contactEditControl.emailTextBox.Text
        //            || Phone != contactEditControl.phoneNumberTextBox.Text;
        //    }

        //    return false;
        //}

        private void DeleteContact(UserControl window)
        {
            //if (window is ContactDetailsWindow dialogWindow)
            //{
            //    using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            //    {
            //        connection.CreateTable<Contact>();
            //        int rows = connection.Delete(Contact);

            //        if (rows == 1)
            //        {
            //            dialogWindow.GetViewModel<ContactDetailsWindowViewModel>().IsDirty = true;
            //        }
            //    }

            //    dialogWindow.DialogResult = true;
            //}
        }

        private void UpdateContact(UserControl window)
        {
            //if (window is ContactDetailsWindow dialogWindow)
            //{
                if (!IsDirty)
                {
                    return;
                }

                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Contact>();
                    int rows = connection.Update(Contact);
                }
                
                //dialogWindow.DialogResult = true;
            //}
        }
    }
}
