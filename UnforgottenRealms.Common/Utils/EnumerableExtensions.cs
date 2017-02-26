using System;
using System.Collections.Generic;
using System.Linq;

namespace UnforgottenRealms.Common.Utils
{
    public static class EnumerableExtensions
    {
        public static void Pop<T>(this Stack<T> stack, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                stack.Pop();
            }
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> first, T second)
        {
            foreach (var item in first)
                yield return item;
            yield return second;
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var item in first)
                yield return item;
            foreach (var item in second)
                yield return item;
        }

        public static T MaxBy<T>(this IEnumerable<T> collection, Func<T, float> selector)
        {
            var maximumElement = collection.First();
            var maximum = selector.Invoke(maximumElement);

            foreach (var item in collection.Skip(1))
            {
                var value = selector.Invoke(item);
                if (value > maximum)
                {
                    maximumElement = item;
                    maximum = value;
                }
            }

            return maximumElement;
        }

        public static IEnumerable<T> Stream<T>(params IEnumerable<T>[] enumerables)
        {
            foreach (var enumerable in enumerables)
                if (enumerable != null)
                    foreach (var item in enumerable)
                        yield return item;
        }
    }
}
