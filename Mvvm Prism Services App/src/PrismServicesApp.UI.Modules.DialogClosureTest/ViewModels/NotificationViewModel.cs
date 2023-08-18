using Prism.Commands;
using Prism.Mvvm;
using PrismServicesApp.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels
{
    public class NotificationViewModel : ViewModelBase
    {
        public DelegateCommand<System.Windows.Data.RelativeSource> CloseDialogCommand { get; private set; }

        public NotificationViewModel()
        {
            CloseDialogCommand = new DelegateCommand<System.Windows.Data.RelativeSource>(CloseDialog);
        }

        private void CloseDialog(System.Windows.Data.RelativeSource parent)
        {
            //var window = Activator.CreateInstance(parent.AncestorType) as Window;
            //window.DialogResult = true;
        }
    }
}
