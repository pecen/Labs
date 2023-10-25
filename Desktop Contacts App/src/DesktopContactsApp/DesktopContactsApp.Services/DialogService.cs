using DesktopContactsApp.Services.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp.Services
{
    public class DialogService : IDialogService
    {
        static Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public static void RegisterDialog<TView, TViewModel>()
        {
            _mappings.Add(typeof(TViewModel), typeof(TView));
        }

        //public void ShowDialog(string name, Action<string> callback)
        //{
        //    var type = Type.GetType($"DialogsInMvvm.{name}");

        //    ShowDialogInternal(type, callback, null);
        //}

        public void ShowDialog<TViewModel>(Action<string> callback, object vm = null)
        {
            var type = _mappings[typeof(TViewModel)];

            ShowDialogInternal(type, callback, typeof(TViewModel), vm);
        }

        //public void ShowDialog<TViewModel>(Action<string> callback, object vm)
        //{
        //    var type = _mappings[typeof(TViewModel)];

        //    ShowDialogInternal(type, callback, typeof(TViewModel));
        //}

        private static void ShowDialogInternal(Type type, Action<string> callback, Type vmType, object viewModel = null)
        {
            //var dialog = Activator.CreateInstance(type) as Window;

            //EventHandler closeEventHandler = null;
            //closeEventHandler = (s, e) =>
            //{
            //    callback(dialog.DialogResult.ToString());
            //    dialog.Closed -= closeEventHandler;
            //};

            //dialog.Closed += closeEventHandler;

            //if(vmType != null)
            //{
            //    var vm = Activator.CreateInstance(vmType);
            //    dialog.DataContext = vm;
            //}

            //dialog.ShowDialog();

            // --- //


            var dialog = new DialogWindowBase();

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
                dialog = s as DialogWindowBase;
                dialog.Close();
            };

            dialog.Closed += closeEventHandler;
            dialog.Closing += Dialog_Closed;

            //var type = Type.GetType($"DialogsInMvvm.{name}");

            var content = Activator.CreateInstance(type);

            if (vmType != null)
            {
                var vm = viewModel != null ? viewModel : Activator.CreateInstance(vmType);
                (content as FrameworkElement).DataContext = vm;
            }

            dialog.Content = content;
            //dialog.xContent.Content = content;

            dialog.ShowDialog();
        }

        private static void Dialog_Closed(object sender, EventArgs e)
        {
            
        }
    }
}
