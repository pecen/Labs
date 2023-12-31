﻿using DesktopContactsApp.Core.Extensions;
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.UI.Wpf.Behaviors
{
    public class NewContactBehavior : Behavior<Button>
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
                var mainWindow = associatedButton.FindParent<MainWindow>();

                if (mainWindow != null)
                {
                    NewContactWindow newContactWindow = new NewContactWindow();
                    newContactWindow.ShowDialog();


                    mainWindow.ReadDatabase();
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
