namespace UnforgottenRealms.Common.Definitions.Entity
{
    public static class UnitsDefinitions
    {
        public static EntityId Archer => UnitId("archer");
        public static EntityId Boat => UnitId("boat");
        public static EntityId Destroyer => UnitId("destroyer");
        public static EntityId Dragon => UnitId("dragon");
        public static EntityId Dreadnought => UnitId("dreadnought");
        public static EntityId Horseman => UnitId("horseman");
        public static EntityId Knight => UnitId("knight");
        public static EntityId Spearsman => UnitId("spearsman");
        public static EntityId Swordsman => UnitId("swordsman");
        public static EntityId Worker => UnitId("worker");


        private static EntityId UnitId(string value) => new EntityId(EntityClass.Unit, value);
    }
}
