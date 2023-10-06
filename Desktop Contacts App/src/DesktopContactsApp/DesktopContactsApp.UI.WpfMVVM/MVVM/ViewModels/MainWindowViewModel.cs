using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.UI.WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Commands

        public DelegateCommand<ViewModelBase> ShowContactDetailsCommand { get; set; }

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

            ShowContactDetailsCommand = new DelegateCommand<ViewModelBase>(ShowContactDetails);   // (o => CurrentView = ContactDetailsWindowVM);

            ReadDatabase();
        }

        private void ShowContactDetails(ViewModelBase obj)
        {
            CurrentView = obj;
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
