using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.UI.WpfMVVM.Controls;
using DesktopContactsApp.UI.WpfMVVM.Models;
using DesktopContactsApp.UI.WpfMVVM.MVVM.Views;
using SQLite;
using System.Windows;

namespace DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels
{
    public class NewContactWindowViewModel : ViewModelBase
    {
        public DelegateCommand<Window> SaveContactCommand { get; set; }

        #region Properties

        private int _id;
        public int Id
        {
            get => _id;
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { SetProperty(ref _email, value); }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set { SetProperty(ref _phone, value); }
        }

        #endregion

        public NewContactWindowViewModel()
        {
            Title = "New Contact";

            SaveContactCommand = new DelegateCommand<Window>(SaveContact,
                o =>
                {
                    return !string.IsNullOrEmpty(Name)
                        && !string.IsNullOrEmpty(Email)
                        && !string.IsNullOrEmpty(Phone);
                });
        }

        private void SaveContact(Window window)
        {
            if (window is NewContactWindow dialogWindow)
            {
                if (dialogWindow.contactEditControl is ContactEditControl)
                {
                    Contact contact = new Contact()
                    {
                        Name = Name,
                        Email = Email,
                        Phone = Phone
                    };

                    using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                    {
                        connection.CreateTable<Contact>();
                        var i = connection.Insert(contact);

                        if (i == 1)
                        {
                            Id = contact.Id;
                            dialogWindow.DialogResult = true;
                        }
                        else
                        {
                            dialogWindow.DialogResult = false;
                        }
                    }
                }
            }
        }
    }
}

