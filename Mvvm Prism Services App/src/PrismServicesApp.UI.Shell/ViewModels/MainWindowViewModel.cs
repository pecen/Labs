using Prism.Commands;
using Prism.Regions;
using PrismServicesApp.Core.Enums;
using PrismServicesApp.Core.Mvvm;

namespace PrismServicesApp.UI.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public string ContentRegion => RegionNames.ContentRegion.ToString();

        // Using Prism's navigation mechanism
        public MainWindowViewModel(IRegionManager regionManager)
        {
            Title = "Prism Services Application";

            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), uri);
        }
    }
}
