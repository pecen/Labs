using Prism.Commands;
using PrismServicesApp.Core.Mvvm;
using PrismServicesApp.Services.Views;
using System.Windows;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels
{
    public class NotificationViewModel : ViewModelBase
    {
        // The following commented out code is not needed if using a Behavior to handle the
        // Click event to close the Notification view, thus the ViewModel is not breaking the
        // MVVM way of doing things by referencing a View-specific object which the code below does. 
        // If you are about to use the code below, the greyed out "usings" above will be used as well. 

        //public DelegateCommand<FrameworkElement> CloseDialogCommand { get; private set; }

        public NotificationViewModel()
        {
            Title = "The Notification";

            //CloseDialogCommand = new DelegateCommand<FrameworkElement>(CloseDialog);
        }

        //private void CloseDialog(FrameworkElement element)
        //{
        //    if (element.Parent is DialogWindow dialogWindow)
        //    {
        //        dialogWindow.DialogResult = true;
        //    }
        //}
    }
}
