using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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

        public static bool AreImagesTheSame(Bitmap b1, Bitmap b2)
        {
            if ((b1 == null) != (b2 == null)) return false;
            if (b1.Size != b2.Size) return false;

            var bd1 = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bd2 = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                var bd1Scan0 = bd1.Scan0;
                var bd2Scan0 = bd2.Scan0;

                var stride = bd1.Stride;
                var len = stride * b1.Height;

                return memcmp(bd1Scan0, bd2Scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bd1);
                b2.UnlockBits(bd2);
            }
        }

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);
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