using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using System;

namespace DialogService.Core.Mvvm
{
    public class ViewModelBase : BindableBase, INavigationAware, IConfirmNavigationRequest, IDestructible
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
