using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Core.Extensions;
using System.Linq;

namespace DesktopContactsApp.UI.Wpf.Behaviors
{
    public class TextChangedBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += AssociatedObjectTextChanged;
        }

        private void AssociatedObjectTextChanged(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject is TextBox associatedTextbox)
            {
                var mainWindow = associatedTextbox.FindParent<MainWindow>();

                if (mainWindow != null)
                {
                    var filteredList = mainWindow.contacts
                        .Where(c => c.Name.ToLower()
                        .Contains(associatedTextbox.Text.ToLower()))
                        .ToList();

                    //var filteredList2 = (from c2 in contacts
                    //                    where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                    //                    orderby c2.Email
                    //                    select c2).ToList();

                    mainWindow.contactsListView.ItemsSource = filteredList;
                }
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= AssociatedObjectTextChanged;
            base.OnDetaching();
        }
    }
}
