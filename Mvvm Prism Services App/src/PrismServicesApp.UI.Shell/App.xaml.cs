using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismServicesApp.Services;
using PrismServicesApp.Services.Interfaces;
using PrismServicesApp.UI.Modules.DialogClosureTest;
using PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels;
using PrismServicesApp.UI.Modules.DialogClosureTest.Views;
using PrismServicesApp.UI.Shell.Views;
using System.Windows;

namespace PrismServicesApp.UI.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule(typeof(DialogClosureTestModule));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            DialogService.RegisterDialog<Notification, NotificationViewModel>();
        }
    }
}
