using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumItTests
{
    public static class Messages
    {
        public static string Display<T>(T given)
        {
            var properties = typeof(T).GetProperties();
            var toDisplay = Environment.NewLine;
            foreach (var property in properties)
                toDisplay += $"{property.Name}: {Objects.GetPropertyValue(given, property.Name)} {Environment.NewLine}";

            return toDisplay;
        }
    }
}
