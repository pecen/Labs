﻿using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.UI.WpfMVVM.Models;

// This is totally wrong since a VM should not know about its View
// This is just for demonstrating purposes
using DesktopContactsApp.UI.WpfMVVM.MVVM.Views;

using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Commands

        public DelegateCommand<Contact> ShowContactDetailsCommand { get; set; }

        #endregion

        #region Properties

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        //private object _currentView;
        //public object CurrentView
        //{
        //    get { return _currentView; }
        //    set
        //    {
        //        SetProperty(ref _currentView, value);
        //    }
        //}

        #endregion

        #region ViewModels

        //public ContactDetailsWindowViewModel ContactDetailsWindowVM { get; set; }

        #endregion

        public MainWindowViewModel()
        {
            Title = "Desktop Contacts App";

            //ContactDetailsWindowVM = new ContactDetailsWindowViewModel();

            ShowContactDetailsCommand = new DelegateCommand<Contact>(ShowContactDetails);      //   o => { CurrentView = ContactDetailsWindowVM; });

            ReadDatabase();
        }

        private void ShowContactDetails(Contact contact)
        {
            if (contact is Contact selectedContact)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow();

                if (contactDetailsWindow.DataContext is ContactDetailsWindowViewModel vm)
                {
                    vm.Id = selectedContact.Id;
                    vm.Name = selectedContact.Name;
                    vm.Email = selectedContact.Email;
                    vm.Phone = selectedContact.Phone;

                    vm.IsDirty = false;

                    contactDetailsWindow.ShowDialog();

                    if (vm.IsDirty)  // == true && contactDetailsWindow.DialogResult == true)
                    {
                        ReadDatabase();
                    }
                }
            }
        }

        public void ReadDatabase()
        {
            IOrderedEnumerable<Contact> contacts;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>()
                            .ToList()
                            .OrderBy(c => c.Name);
            }

            if (contacts != null)
            {
                Contacts = new ObservableCollection<Contact>(contacts);
            }
        }
    }
}
