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

    }
}
