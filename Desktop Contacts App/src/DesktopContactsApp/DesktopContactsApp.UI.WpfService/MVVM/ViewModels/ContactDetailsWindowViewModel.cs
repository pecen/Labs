using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.Services;
using DesktopContactsApp.UI.WpfService.Models;
using DesktopContactsApp.UI.WpfService.MVVM.Views;
using SQLite;
using System.Windows;

namespace DesktopContactsApp.UI.WpfService.MVVM.ViewModels
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

            UpdateContactCommand = new DelegateCommand<Window>(UpdateContact,
                o =>
                {
                    return IsDirty
                        && !string.IsNullOrEmpty(Name)
                        && !string.IsNullOrEmpty(Email)
                        && !string.IsNullOrEmpty(Phone);
                });
            DeleteContactCommand = new DelegateCommand<Window>(DeleteContact,
                o =>
                {
                    return !string.IsNullOrEmpty(Name)
                        || !string.IsNullOrEmpty(Email)
                        || !string.IsNullOrEmpty(Phone);
                });
        }

        private void DeleteContact(Window window)
        {
            if (window is ContactDetailsWindow dialogWindow)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    connection.CreateTable<Contact>();
                    int rows = connection.Delete(Contact);

                    if (rows == 1)
                    {
                        dialogWindow.GetViewModel<ContactDetailsWindowViewModel>().IsDirty = true;
                    }
                }

                dialogWindow.DialogResult = true;
            }
        }

        private void UpdateContact(Window window)
        {
            if (window is ContactDetailsWindow dialogWindow)
            {
                if (!IsDirty)
                {
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
