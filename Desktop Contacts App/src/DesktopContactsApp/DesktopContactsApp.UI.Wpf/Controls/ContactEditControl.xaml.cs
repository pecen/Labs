using DesktopContactsApp.UI.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp.UI.Wpf.Controls
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
            ContactEditControl control = d as ContactEditControl;

            if (control != null)
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

