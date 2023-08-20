using Microsoft.Xaml.Behaviors;
using PrismServicesApp.Core.Extensions;
using PrismServicesApp.Services.Views;
using System.Windows;
using System.Windows.Controls;

namespace PrismServicesApp.UI.Modules.DialogClosureTest.Behaviors
{
    public class CloseDialogBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObjectClick;
        }

        private void AssociatedObjectClick(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is Button associatedButton)
            {
                var dialogWindow = associatedButton.FindAncestor<DialogWindow>();

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
