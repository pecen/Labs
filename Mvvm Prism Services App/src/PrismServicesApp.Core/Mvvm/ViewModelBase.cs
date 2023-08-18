using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismServicesApp.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IConfirmNavigationRequest, IDestructible
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
            
        }

        public void Destroy()
        {
            
        }
    }
}
