namespace UnforgottenRealms.Common.Definitions.Entity
{
    public struct EntityId
    {
        public EntityClass Class { get; }
        public string Value { get; }

        public EntityId(EntityClass @class, string value)
        {
            Class = @class;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityId))
                return false;
            return this == (EntityId)obj;
        }

        public override int GetHashCode() => Value.GetHashCode() * 7 * Class.GetHashCode();

        public static bool operator == (EntityId id1, EntityId id2) => id1.Class == id2.Class && id1.Value == id2.Value;
        public static bool operator !=(EntityId id1, EntityId id2) => !(id1 == id2);
    }
}
