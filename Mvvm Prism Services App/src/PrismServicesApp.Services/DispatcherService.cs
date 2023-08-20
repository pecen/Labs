using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace PrismServicesApp.Services
{
    public static class DispatcherService
    {
        /// <summary>
        /// Executes the action in dispatcher context 
        /// by checking if action should be invoked by dispatcher, or directly, and running it.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="sender">The sender object in context of which action should be executed.</param>
        /// <param name="wait">if set to <c>true</c> waits for execution end.</param>
        public static void ExecuteActionInDispatcherContext(Action action, DependencyObject? sender = null, bool wait = true)
        {
            if (Application.Current == null || Application.Current.Dispatcher.CheckAccess())
            {
                // CheckAccess returns true if you're on the dispatcher thread
                action();
            }
            else
            {
                DispatcherObject dispatcherObject;
                if (sender != null)
                {
                    dispatcherObject = sender;
                }
                else
                {
                    dispatcherObject = Application.Current;
                }
                if (wait)
                {
                    dispatcherObject.Dispatcher.Invoke(action);
                }
                else
                {
                    dispatcherObject.Dispatcher.BeginInvoke(action);
                }
            }
        }

        /// <summary>
        /// Shows the view and waits until it's closed.
        /// </summary>
        /// <param name="view">The view.</param>
        public static void ShowView(Window view)
        {
            SynchronizationContext.SetSynchronizationContext(
                new DispatcherSynchronizationContext(
                    Dispatcher.CurrentDispatcher));

            view.Closed += (s, e) =>
                Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

            view.Show();
            Dispatcher.Run();
        }
    }
}
