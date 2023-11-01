using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.Services;
using DesktopContactsApp.UI.WpfService.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace DesktopContactsApp.UI.WpfService.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        #region Commands

        public DelegateCommand<Contact> ShowContactDetailsCommand { get; set; }
        public DelegateCommand LaunchGitHubSiteCommand { get; set; }
        public DelegateCommand DeployCupCakesCommand { get; set; }

        #endregion

        #region Properties

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        #endregion

        public MainWindowViewModel()
        {
            Title = "Desktop Contacts App";

            _dialogService = new DialogService();

            ShowContactDetailsCommand = new DelegateCommand<Contact>(ShowContactDetails);      //   o => { CurrentView = ContactDetailsWindowVM; });
            LaunchGitHubSiteCommand = new DelegateCommand(LaunchGitHubSite);
            DeployCupCakesCommand = new DelegateCommand(DeployCupCakes);

            ReadDatabase();
        }

        private void DeployCupCakes()
        {
            //Process.Start("https://www.bbcgoodfood.com/recipes/cupcakes");
            Process.Start("https://vapiano.se");
        }

        private void LaunchGitHubSite()
        {
            Process.Start("https://www.github.com");
        }

        private void ShowContactDetails(Contact contact)
        {
            if (contact is Contact selectedContact)
            {
                var vm = new ContactDetailsWindowViewModel
                {
                    Id = selectedContact.Id,
                    Name = selectedContact.Name,
                    Email = selectedContact.Email,
                    Phone = selectedContact.Phone,
                };

                _dialogService.ShowDialog<ContactDetailsWindowViewModel>(result => { var test = result; });

                //ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow();

                //if (contactDetailsWindow.DataContext is ContactDetailsWindowViewModel vm)
                //{
                //    vm.Id = selectedContact.Id;
                //    vm.Name = selectedContact.Name;
                //    vm.Email = selectedContact.Email;
                //    vm.Phone = selectedContact.Phone;

                //    vm.IsDirty = false;

                //    contactDetailsWindow.ShowDialog();

                //    if (vm.IsDirty)  // == true && contactDetailsWindow.DialogResult == true)
                //    {
                //        ReadDatabase();
                //    }
                //}
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
