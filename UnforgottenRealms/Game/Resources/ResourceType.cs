using System;

namespace UnforgottenRealms.Game.Resources
{
    public enum ResourceType
    {
        Food,
        Wood,
        Iron,
        Gems
    }

    public static class ResourcesExtensions
    {
        private static ResourceType[] ResourcesTypes => (ResourceType[])Enum.GetValues(typeof(ResourceType));

        public static Resource[] CreateEach()
        {
            var resources = new Resource[ResourcesTypes.Length];
            for (int i = 0; i < ResourcesTypes.Length; i++)
                resources[i] = new Resource(ResourcesTypes[i]);
            return resources;
        }
    }
}
