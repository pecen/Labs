﻿using DesktopContactsApp.Core.Extensions;
using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.UI.WpfMVVM.Models;
using DesktopContactsApp.UI.WpfMVVM.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            private set { SetProperty(ref _contacts, value); }
        }

        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; }
        }


        #endregion

        #region ViewModels

        public ContactDetailsWindowViewModel ContactDetailsWindowVM { get; set; }

        #endregion

        public MainWindowViewModel()
        {
            Title = "Desktop Contacts App";

            ContactDetailsWindowVM = new ContactDetailsWindowViewModel();

            ShowContactDetailsCommand = new DelegateCommand<Contact>(ShowContactDetails);   // (o => CurrentView = ContactDetailsWindowVM);

            ReadDatabase();
        }

        private void ShowContactDetails(object obj)
        {
            if (obj is Contact selectedContact)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow();

                if (contactDetailsWindow.DataContext is ContactDetailsWindowViewModel vm)
                {
                    vm.Name = selectedContact.Name;
                    vm.Email = selectedContact.Email;
                    vm.Phone = selectedContact.Phone;

                    contactDetailsWindow.ShowDialog();
                }

                ReadDatabase();
            }
        }

        public void ReadDatabase()
        {
            IOrderedEnumerable<Contact> contacts;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>()
                            .ToList())
                            .OrderBy(c => c.Name); 
            }

            if (contacts != null)
            {
                Contacts = new ObservableCollection<Contact>(contacts);
            }
        }
    }
}
