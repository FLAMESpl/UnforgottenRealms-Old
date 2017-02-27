namespace UnforgottenRealms.Common.Definitions.Entity
{
    public static class TerrainDefinitions
    {
        public static EntityId Desert => TerrainId("desert");
        public static EntityId Forest => TerrainId("forest");
        public static EntityId Grass => TerrainId("grass");
        public static EntityId Hill => TerrainId("hill");
        public static EntityId Mountain => TerrainId("mountain");
        public static EntityId Water => TerrainId("water");

        private static EntityId TerrainId(string value) => new EntityId(EntityClass.Terrain, value);
    }
}
