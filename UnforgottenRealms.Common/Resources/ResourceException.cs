using System;

namespace UnforgottenRealms.Common.Resources
{
    public class ResourceException : Exception
    {
        public ResourceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
