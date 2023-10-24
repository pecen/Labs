using System.Windows;

namespace DesktopContactsApp.Services.Views
{
    /// <summary>
    /// Interaction logic for DialogWindowBase.xaml
    /// </summary>
    public partial class DialogWindowBase : Window
    {
        public DialogWindowBase()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
        }
    }
}
