using System;
using System.Collections.Generic;

namespace UnforgottenRealms.Common.Resources
{
    public class ResourceManager
    {
        private Dictionary<Type, IResource> resources = new Dictionary<Type, IResource>();

        public void Add<T>(T resource) where T : IResource
        {
            resources.Add(typeof(T), resource);
        }

        public T Get<T>() where T : IResource
        {
            try
            {
                return (T)(resources[typeof(T)]);
            }
            catch (Exception ex)
            {
                throw new ResourceException("Could not load resource", ex);
            }
        }
    }
}
