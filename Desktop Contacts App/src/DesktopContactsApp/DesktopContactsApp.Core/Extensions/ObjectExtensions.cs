using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Utilities.Extensions
{
    public static class ObjectExtensions
    {
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            PropertyInfo propInfo = obj.GetType().GetProperty(propertyName); //this returns null
            var itemValue = propInfo.GetValue(obj, null);

            return itemValue;
        }
    }
}
