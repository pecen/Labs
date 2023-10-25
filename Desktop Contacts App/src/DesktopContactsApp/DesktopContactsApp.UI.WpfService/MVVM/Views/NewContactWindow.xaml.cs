using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.WpfService.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : UserControl // Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            //Owner = Application.Current.MainWindow;
        }
    }
}
