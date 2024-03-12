using DesktopContactsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp.Utilities.Helpers
{
    public static class ViewModelHelpers
    {

        /// <summary>
        /// Gets the view model from given sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <returns>View model.</returns>
        public static TViewModel GetViewModel<TViewModel>(this DependencyObject sender)
        {
            FrameworkElement element = (FrameworkElement)sender;
            TViewModel res = default;

            element.ExecuteActionInDispatcherContext(() =>
            {
                res = (TViewModel)element.DataContext;
            });
            return res;
        }

        /// <summary>
        /// Checks if action should be invoked by dispatcher, or directly and runs it.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="action">The action to run.</param>
        public static void ExecuteActionInDispatcherContext(this DependencyObject sender, Action action)
        {
            DispatcherService.ExecuteActionInDispatcherContext(action, sender);
        }
    }
}
