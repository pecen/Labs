using DesktopContactsApp.UI.WpfMVVM.Models;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfMVVM.Controls
{
    /// <summary>
    /// Interaction logic for ContactEditControl.xaml
    /// </summary>
    public partial class ContactEditControl : UserControl
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactEditProperty); }
            set { SetValue(ContactEditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactEditProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactEditControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContactEditControl control)
            {
                control.nameTextBox.Text = (e.NewValue as Contact).Name;
                control.emailTextBox.Text = (e.NewValue as Contact).Email;
                control.phoneNumberTextBox.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactEditControl()
        {
            InitializeComponent();
        }
    }
}
