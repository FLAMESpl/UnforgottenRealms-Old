using System.Collections.Generic;

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

        public static IEnumerable<T> Stream<T>(params IEnumerable<T>[] enumerables)
        {
            foreach (var enumerable in enumerables)
                if (enumerable != null)
                    foreach (var item in enumerable)
                        yield return item;
        }
    }
}
