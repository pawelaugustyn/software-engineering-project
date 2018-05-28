using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumItTests
{
    public static class Objects
    {
        public static object GetPropertyValue(this object objectName, string propertyName)
            => objectName.GetType().GetProperty(propertyName)?.GetValue(objectName, null);

        public static string WithUniqueName(this string name)
            => $"{name}({Guid.NewGuid()})";
    }
}
