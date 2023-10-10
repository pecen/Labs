using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.UI.WpfMVVM.Models;
using DesktopContactsApp.UI.WpfMVVM.MVVM.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels
{
    public class ContactDetailsWindowViewModel : ViewModelBase
    {
        public DelegateCommand<Window> UpdateContactCommand { get; set; }
        public DelegateCommand<Window> DeleteContactCommand { get; set; }

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

        private Contact Contact
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

        //private Contact _contact = new Contact();
        //public Contact Contact
        //{
        //    get => _contact;
        //    set { IsDirty = SetProperty(ref _contact, value); }
        //}

        #endregion

        public ContactDetailsWindowViewModel()
        {
            Title = "Contact Details";

            UpdateContactCommand = new DelegateCommand<Window>(UpdateContact,
                o =>
                {
                    return IsDirty
                        && !string.IsNullOrEmpty(Contact.Name)
                        && !string.IsNullOrEmpty(Contact.Email)
                        && !string.IsNullOrEmpty(Contact.Phone);
                });
            DeleteContactCommand = new DelegateCommand<Window>(DeleteContact,
                o =>
                {
                    return !string.IsNullOrEmpty(Contact.Name)
                        || !string.IsNullOrEmpty(Contact.Email)
                        || !string.IsNullOrEmpty(Contact.Phone);
                });
        }

        private void DeleteContact(Window window)
        {
            if (window is ContactDetailsWindow dialogWindow)
            {
                dialogWindow.DialogResult = true;
            }
        }

        private void UpdateContact(Window window)
        {
            if (window is ContactDetailsWindow dialogWindow)
            {
                if (!IsDirty)
                {
                    dialogWindow.DialogResult = false;
                    return;
                }

                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Contact>();
                    int rows = connection.Update(Contact);
                }

                dialogWindow.DialogResult = true;
            }
        }
    }
}
