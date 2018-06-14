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
                Assert.That(false, Is.True, $"{message} {Environment.NewLine} {e.Message}Element: {Environment.NewLine}{Messages.Display(given)}{Environment.NewLine} should be equal to {Environment.NewLine}{Messages.Display(expected)}.{Environment.NewLine}");
            }
        }

        public static void NotEquals<T>(T given, T expected, string message = "")
        {
            try
            {
                given.ShouldDeepEqual(expected, new ObjectsWithExceptionComparer());

                Assert.That(false, Is.True, $"{message} {Environment.NewLine} Elements: {Environment.NewLine}{Messages.Display(given)}{Environment.NewLine} should not be equal.{Environment.NewLine}");
            }
            catch (DeepEqualException) { }
        }

        public static void ListContains<T>(this List<T> givenList, T expectedItem)
        {
            var user = GetItemFromList(givenList, expectedItem);

            Assert.That(user, !Is.EqualTo(default(T)), $"Element do not exist on the list. Expected: {Messages.Display(expectedItem)}");
        }

        public static void ListNotContains<T>(this List<T> givenList, T notExpectedItem)
        {
            var user = GetItemFromList(givenList, notExpectedItem);

            Assert.That(user, Is.EqualTo(default(T)), $"Element should not exist on the list. Element: {Messages.Display(notExpectedItem)}");
        }

        private static T GetItemFromList<T>(IEnumerable<T> givenList, T expectedItem)
        {
            var user = default(T);

            foreach (var given in givenList)
            {
                var isEqual = given.IsDeepEqual(expectedItem, new ObjectsComparer());
                if (!isEqual) continue;
                user = given;
                break;
            }

            return user;
        }
    }
}
