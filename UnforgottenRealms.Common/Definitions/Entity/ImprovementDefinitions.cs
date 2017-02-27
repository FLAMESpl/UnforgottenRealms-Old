namespace UnforgottenRealms.Common.Definitions.Entity
{
    public static class ImprovementDefinitions
    {
        public static EntityId Barracks => ImprovementId("barracks");
        public static EntityId DragonLair => ImprovementId("dragonlair");
        public static EntityId Farm => ImprovementId("farm");
        public static EntityId Mine => ImprovementId("mine");
        public static EntityId LumberjacksHut => ImprovementId("lumberjacks");
        public static EntityId Shipyard => ImprovementId("shipyard");
        public static EntityId Stable => ImprovementId("stable");

        private static EntityId ImprovementId(string value) => new EntityId(EntityClass.Improvement, value);
    }
}
