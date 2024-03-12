using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfService.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : UserControl // Window
    {
        public ContactDetailsWindow()
        {
            InitializeComponent();

            //Owner = Application.Current.MainWindow;
        }
    }
}
