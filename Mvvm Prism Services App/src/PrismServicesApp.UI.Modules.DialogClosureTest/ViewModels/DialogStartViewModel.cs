using Prism.Commands;
using Prism.Mvvm;
using PrismServicesApp.Core.Mvvm;
using PrismServicesApp.Services;
using PrismServicesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels
{
    public class DialogStartViewModel : ViewModelBase
    {
        private IDialogService _dialogService; // = new DialogService();

        public DelegateCommand ShowDialog { get; private set; }

        public DialogStartViewModel(IDialogService dialogService)
        {
            Title = "Prism Dialog Service";

            _dialogService = dialogService;

            ShowDialog = new DelegateCommand(ExecuteShowDialog);
        }

        private void ExecuteShowDialog()
        {
            _dialogService.ShowDialog<NotificationViewModel>(result =>
            {
                var test = result;
            });
        }
    }
}
