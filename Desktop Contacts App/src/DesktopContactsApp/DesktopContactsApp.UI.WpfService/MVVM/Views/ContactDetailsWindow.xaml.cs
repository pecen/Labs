using System.Windows;

namespace DesktopContactsApp.UI.WpfService.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        public ContactDetailsWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
        }
    }
}
