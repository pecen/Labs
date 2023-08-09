using DialogService.UI.Shell.Modules.ModuleName;
using DialogService.UI.Shell.Services;
using DialogService.UI.Shell.Services.Interfaces;
using DialogService.UI.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DialogService.UI.Shell
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
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
