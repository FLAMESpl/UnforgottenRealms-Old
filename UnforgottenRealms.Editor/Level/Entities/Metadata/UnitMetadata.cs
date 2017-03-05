using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Editor.Level.Entities.Metadata
{
    public class UnitMetadata : IEntityMetadata
    {
        public EntityId EntityId { get; }
        public bool IsEmpty { get; }
        public PlayerColour? Owner { set; get; }
        public Tile Tile { get; }

        public UnitMetadata(EntityId entityId, Tile tile, PlayerColour? owner)
        {
            EntityId = entityId;
            IsEmpty = entityId.Value == null;
            Owner = owner;
            Tile = tile;
        }

        public UnitMetadata(UnitMetadata metadata)
        {
            EntityId = metadata.EntityId;
            IsEmpty = metadata.IsEmpty;
            Owner = metadata.Owner;
            Tile = metadata.Tile;
        }

        public static UnitMetadata Empty => new UnitMetadata(new EntityId(EntityClass.Unit, null), null, null);
    }
}
