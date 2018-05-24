using NUnit.Framework;

namespace ScrumItTests
{
    public static class Assertion
    {
        public static void Equals<T>(T given, T expected)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var givenPropertyValue = Objects.GetPropertyValue(given, property.Name);
                var expectedPropertyValue = Objects.GetPropertyValue(expected, property.Name);

                Assert.That(givenPropertyValue, Is.EqualTo(expectedPropertyValue), $"{property.Name} value is {givenPropertyValue} but sholud be {expectedPropertyValue}");
            }
        }
    }
}
