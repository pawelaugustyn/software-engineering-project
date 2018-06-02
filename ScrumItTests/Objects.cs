using System;
using DeepEqual;
using DeepEqual.Syntax;
using static System.String;


namespace ScrumItTests
{
    public static class Objects
    {
        public static object GetPropertyValue(this object objectName, string propertyName)
            => objectName.GetType().GetProperty(propertyName)?.GetValue(objectName, null);

        public static string WithUniqueName(this string name)
            => $"{name}({Guid.NewGuid()})";
    }

    public class ObjectsWithExceptionComparer : IComparison
    {
        public bool CanCompare(Type type1, Type type2)
            => type1 == type2;

        public ComparisonResult Compare(IComparisonContext context, object given, object expected)
        {
            var properties = given.GetType().GetProperties();
            var message = Empty;

            foreach (var property in properties)
            {
                if (property?.PropertyType.FullName == "System.Drawing.Image")
                    continue;

                var givenPropertyValue = given.GetPropertyValue(property?.Name);
                var expectedPropertyValue = expected.GetPropertyValue(property?.Name);

                if ((givenPropertyValue != null && expectedPropertyValue != null) && (!givenPropertyValue.Equals(expectedPropertyValue)))
                    message += $"{property?.Name} value is {givenPropertyValue} but sholud be {expectedPropertyValue} {Environment.NewLine}";
            }
            if (message.Equals(Empty))
                return ComparisonResult.Pass;
            throw new DeepEqualException(message);
        }
    }

    public class ObjectsComparer : IComparison
    {
        public bool CanCompare(Type type1, Type type2)
            => type1 == type2;

        public ComparisonResult Compare(IComparisonContext context, object given, object expected)
        {
            var properties = given.GetType().GetProperties();
            var message = Empty;

            foreach (var property in properties)
            {
                if (property?.PropertyType.FullName == "System.Drawing.Image")
                    continue;

                var givenPropertyValue = given.GetPropertyValue(property?.Name);
                var expectedPropertyValue = expected.GetPropertyValue(property?.Name);

                if ((givenPropertyValue != null && expectedPropertyValue != null) &&
                    (!givenPropertyValue.Equals(expectedPropertyValue)))
                    message +=
                        $"{property?.Name} value is {givenPropertyValue} but sholud be {expectedPropertyValue} {Environment.NewLine}";
            }

            return message.Equals(Empty) ? ComparisonResult.Pass : ComparisonResult.Fail;
        }
    }
}