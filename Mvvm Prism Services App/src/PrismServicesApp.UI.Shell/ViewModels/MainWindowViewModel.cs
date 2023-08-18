using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismServicesApp.Core.Enums;
using PrismServicesApp.Core.Mvvm;
using System;

namespace PrismServicesApp.UI.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public string ContentRegion => RegionNames.ContentRegion.ToString();

        private string _title = "Prism Services Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // Using Prism's navigation mechanism
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), uri);
        }
    }
}
