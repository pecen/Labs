using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Services
{
    public interface IDialogService
    {
        void ShowDialog<TViewModel>(Action<string> callback);
    }
}
