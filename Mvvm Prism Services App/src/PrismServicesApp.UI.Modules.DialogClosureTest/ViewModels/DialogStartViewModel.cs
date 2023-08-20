using Prism.Commands;
using PrismServicesApp.Core.Mvvm;
using PrismServicesApp.Services.Interfaces;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels
{
    public class DialogStartViewModel : ViewModelBase
    {
        private IDialogService _dialogService; // = new DialogService();

        public DelegateCommand ShowDialog { get; private set; }

        public DialogStartViewModel(IDialogService dialogService)
        {
            Title = "The Dialog Service";

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
