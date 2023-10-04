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
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;

            this.contact = contact;

            contactEditControl.nameTextBox.Text = contact.Name;
            contactEditControl.phoneNumberTextBox.Text = contact.Phone;
            contactEditControl.emailTextBox.Text = contact.Email;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = contactEditControl.nameTextBox.Text;
            contact.Phone = contactEditControl.phoneNumberTextBox.Text;
            contact.Email = contactEditControl.emailTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();
        }
    }
}
