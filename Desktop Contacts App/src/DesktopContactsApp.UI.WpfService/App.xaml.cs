using DesktopContactsApp.Services;
using DesktopContactsApp.UI.WpfService.MVVM.ViewModels;
using DesktopContactsApp.UI.WpfService.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp.UI.WpfService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = Path.Combine(folderPath, databaseName);

        public App()
        {
            DialogService.RegisterDialog<NewContactWindow, NewContactWindowViewModel>();
            DialogService.RegisterDialog<ContactDetailsWindow, ContactDetailsWindowViewModel>();
        }
    }
}
