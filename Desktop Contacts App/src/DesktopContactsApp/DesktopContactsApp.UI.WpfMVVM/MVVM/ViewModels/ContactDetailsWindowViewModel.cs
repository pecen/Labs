using DesktopContactsApp.Core.MVVM;
using DesktopContactsApp.UI.WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.UI.WpfMVVM.MVVM.ViewModels
{
    public class ContactDetailsWindowViewModel : ViewModelBase
    {
        public DelegateCommand<Contact> UpdateContactCommand { get; set; }
        public DelegateCommand<Contact> DeleteContactCommand { get; set; }

        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                SetProperty(ref _phone, value);
            }
        }

        #endregion

        public ContactDetailsWindowViewModel()
        {
            Title = "Contact Details";

            UpdateContactCommand = new DelegateCommand<Contact>(UpdateContact, CanUpdate);
            DeleteContactCommand = new DelegateCommand<Contact>(DeleteContact, CanDelete);
        }

        private bool CanDelete(object contact)
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Phone);
        }

        private void DeleteContact(object contact)
        {
        }

        private bool CanUpdate(Contact contact)
        {
            return !(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Phone));
        }

        private void UpdateContact(Contact contact)
        {
        }
    }
}
