using DesktopContactsApp.UI.WpfMVVM.Models;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfMVVM.Controls
{
    /// <summary>
    /// Interaction logic for ContactInfoControl.xaml
    /// </summary>
    public partial class ContactInfoControl : UserControl
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactInfoProperty); }
            set { SetValue(ContactInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactInfoProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactInfoControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContactInfoControl control)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactInfoControl()
        {
            InitializeComponent();
        }
    }
}
