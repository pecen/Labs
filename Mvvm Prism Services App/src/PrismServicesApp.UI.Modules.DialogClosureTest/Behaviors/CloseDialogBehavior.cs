using Microsoft.Xaml.Behaviors;
using PrismServicesApp.Services.Views;
using PrismServicesApp.UI.Modules.DialogClosureTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.Behaviors
{
    public class CloseDialogBehavior : Behavior<Button>
    {
        public static T FindAncestor<T>(DependencyObject obj)
            where T : DependencyObject
        {
            if (obj != null)
            {
                var dependObj = obj;
                do
                {
                    dependObj = GetParent(dependObj);
                    if (dependObj is T)
                        return dependObj as T;
                }
                while (dependObj != null);
            }

            return null;
        }

        public static DependencyObject GetParent(DependencyObject obj)
        {
            if (obj == null)
                return null;
            if (obj is ContentElement)
            {
                var parent = ContentOperations.GetParent(obj as ContentElement);
                if (parent != null)
                    return parent;
                if (obj is FrameworkContentElement)
                    return (obj as FrameworkContentElement).Parent;
                return null;
            }

            return VisualTreeHelper.GetParent(obj);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObjectClick;
        }

        private void AssociatedObjectClick(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is Button associatedButton)
            {
                var dialogWindow = FindAncestor<DialogWindow>(associatedButton);
                if (dialogWindow != null)
                {
                    dialogWindow.DialogResult = true;
                }
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObjectClick;
            base.OnDetaching();
        }
    }
}
