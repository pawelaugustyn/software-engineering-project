using System;
using System.Collections.Generic;
using DeepEqual.Syntax;
using NUnit.Framework;

namespace ScrumItTests
{
    public static class Assertion
    {
        public static void Equals<T>(T given, T expected, string message = "")
        {
            try
            {
                given.ShouldDeepEqual(expected, new ObjectsWithExceptionComparer());
            }
            catch (DeepEqualException e)
            {
                Assert.That(false, Is.True, $"{message} {Environment.NewLine} Element not found.{Environment.NewLine} {e.Message}");
            }
        }

        public static void ListContains<T>(this List<T> givenList, T expected)
        {
            var user = default(T);

            foreach (var given in givenList)
            {
                var isEqual = given.IsDeepEqual(expected, new ObjectsComparer());
                if (!isEqual) continue;
                user = given;
                break;
            }
            Assert.That(user, !Is.EqualTo(default(T)), $"Element do not exist on the list. Expected: {Messages.Display(expected)}");
        }
    }
}
