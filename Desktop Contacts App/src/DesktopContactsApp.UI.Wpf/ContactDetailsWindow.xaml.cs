using DesktopContactsApp.UI.Wpf.Models;
using SQLite;
using System.Windows;

namespace DesktopContactsApp.UI.Wpf
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact _contact;
        bool _isDirty;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;

            _contact = contact;

            contactEditControl.nameTextBox.Text = contact.Name;
            contactEditControl.phoneNumberTextBox.Text = contact.Phone;
            contactEditControl.emailTextBox.Text = contact.Email;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if(_contact.Name == contactEditControl.nameTextBox.Text
                && _contact.Phone == contactEditControl.phoneNumberTextBox.Text
                && _contact.Email == contactEditControl.emailTextBox.Text)
            {
                DialogResult = false;
                return;
            }

            _contact.Name = contactEditControl.nameTextBox.Text;
            _contact.Phone = contactEditControl.phoneNumberTextBox.Text;
            _contact.Email = contactEditControl.emailTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            }

            DialogResult = true;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
            }

            Close();
        }
    }
}
