using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanIntegration.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
            => value == null;

        public static bool IsNotNull(this object value)
            => value != null;

        public static bool IsNullOrWhiteSpace(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static bool IsNotNullOrWhiteSpace(this string value)
            => !string.IsNullOrWhiteSpace(value);

        public static bool IsEmpty<T>(this IEnumerable<T> enumarable)
            => enumarable.Count() <= 0;

        public static bool HaveItems<T>(this IEnumerable<T> enumarable)
            => enumarable.Count() > 0;

        public static IEnumerable<T> EmptyCollection<T>()
            => new List<T>();
    }
}
