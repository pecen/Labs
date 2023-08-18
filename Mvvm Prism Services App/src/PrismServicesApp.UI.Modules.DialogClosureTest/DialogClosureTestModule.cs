using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
//using Prism.Services.Dialogs;
using PrismServicesApp.Core.Enums;
using PrismServicesApp.Services;
using PrismServicesApp.Services.Interfaces;
using PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels;
using PrismServicesApp.UI.Modules.DialogClosureTest.Views;

namespace PrismServicesApp.UI.Modules.DialogClosureTest
{
    public class DialogClosureTestModule : IModule
    {
        // Making this field immutable. An immutable field is good for
        // caching purposes because you don't have to worry about the
        // value changes. An immutable field is inherently thread-safe,
        // so you don't have to worry about thread safety in multi-threaded environments.
        // One of the main benefits of immutability is that it makes it easier to write
        // concurrent and multi-threaded code. Since immutable objects cannot be modified,
        // there is no need for locks or other synchronization mechanisms to ensure that
        // multiple threads do not access or modify the same object at the same time.
        private readonly IRegionManager _regionManager;

        public DialogClosureTestModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //_regionManager = containerProvider.Resolve<IRegionManager>();

            // View Injection
            //IRegion region = _regionManager.Regions[RegionNames.ContentRegion.ToString()];
            //var dialogStart = containerProvider.Resolve<DialogStart>();
            //region.Add(dialogStart);

            // View Discovery
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion.ToString(), typeof(DialogStart));

            // Prism's navigation mechanism
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), nameof(DialogStart));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DialogStart>();

            //containerRegistry.RegisterSingleton<IDialogService, DialogService>();

            //DialogService.RegisterDialog<Notification, NotificationViewModel>();
        }
    }
}