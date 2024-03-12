using MahApps.Metro.Controls;
using System.Windows;

namespace DesktopContactsApp.Services.Views
{
    /// <summary>
    /// Interaction logic for DialogWindowBase.xaml
    /// </summary>
    public partial class DialogWindowBase : MetroWindow
    {
        public DialogWindowBase()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
        }
    }
}
