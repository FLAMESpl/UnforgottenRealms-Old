using System.Collections.Generic;

namespace UnforgottenRealms.Game.Resources
{
    public class ResourceSet
    {
        private Dictionary<ResourceType, Resource> resources;

        public IReadOnlyDictionary<ResourceType, Resource> Resources => resources;

        public ResourceSet(params Resource[] resources)
        {
            foreach (var resource in resources)
                this.resources.Add(resource.Type, resource);
        }

        public static ResourceSet operator + (ResourceSet set, Resource resource)
        {
            set.Resources[resource.Type].Amount += resource.Amount;
            return set;
        }

        public static ResourceSet operator - (ResourceSet set, Resource resource)
        {
            set.Resources[resource.Type].Amount -= resource.Amount;
            return set;
        }
    }
}
