using System.Windows;
using System.Windows.Media;

namespace DesktopContactsApp.Core.Extensions
{
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Finds the first occurence of the requested ancestor. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T FindAncestor<T>(this DependencyObject obj)
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

        /// <summary>
        /// Finds the first occurence of the requested parent. Basically does the same
        /// as the previous method, FindAncestor<T>, but with a different approach. The
        /// name difference is just because they both have the same signature, and therefore
        /// can't have the same method name. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                return null;
            }

            if (parentObject is T parent)
            {
                return parent;
            }

            return parentObject.FindParent<T>();
        }

        /// <summary>
        /// Gets the Parent to an object in the visual tree
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static DependencyObject GetParent(DependencyObject obj)
        {
            if (obj == null)
                return null;
            if (obj is ContentElement)
            {
                var parent = ContentOperations.GetParent(obj as ContentElement);
                if (parent != null)
                    return parent;
                if (obj is FrameworkContentElement)
                    return ((FrameworkContentElement)obj).Parent;
                return null;
            }

            return VisualTreeHelper.GetParent(obj);
        }
    }
}
