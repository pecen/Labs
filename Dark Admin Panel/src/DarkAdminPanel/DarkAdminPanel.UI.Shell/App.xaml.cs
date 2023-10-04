using DarkAdminPanel.UI.Modules.LeftNavMenu;
using DarkAdminPanel.UI.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DarkAdminPanel.UI.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule(typeof(LeftNavMenuModule));
        }
    }
}
