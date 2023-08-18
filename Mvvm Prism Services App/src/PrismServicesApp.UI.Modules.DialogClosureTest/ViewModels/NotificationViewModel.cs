using Prism.Commands;
using Prism.Mvvm;
using PrismServicesApp.Core.Mvvm;
using PrismServicesApp.Services.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels
{
    public class NotificationViewModel : ViewModelBase
    {
        public DelegateCommand<FrameworkElement> CloseDialogCommand { get; private set; }

        public NotificationViewModel()
        {
            CloseDialogCommand = new DelegateCommand<FrameworkElement>(CloseDialog);
        }

        private void CloseDialog(FrameworkElement element)
        {
            if (element.Parent is DialogWindow dialogWindow)
            {
                dialogWindow.DialogResult = true;
            }
        }
    }
}
