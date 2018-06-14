using System;

namespace ScrumItTests
{
    public static class Messages
    {
        public static string Display<T>(T given)
        {
            var properties = typeof(T).GetProperties();
            var toDisplay = Environment.NewLine;
            foreach (var property in properties)
                toDisplay += $"{property.Name}: {given.GetPropertyValue(property.Name)} {Environment.NewLine}";

            return toDisplay;
        }
    }
}
