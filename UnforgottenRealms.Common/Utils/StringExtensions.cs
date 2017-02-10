namespace UnforgottenRealms.Common.Utils
{
    public static class StringExtensions
    {
        public static string RemoveLast(this string @this) => (@this.Length > 0) ? @this.Remove(@this.Length - 1) : @this;

        public static bool IsDigit(this char @this)
        {
            var code = (int)@this;
            return code > 47 && code < 58;
        }

        public static int AsNumber(this char @this) => @this - 48;
    }
}
