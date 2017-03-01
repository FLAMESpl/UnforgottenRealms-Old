using System;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class DepositMetadata : IEntityMetadata
    {
        public EntityId EntityId { get; }
        public bool IsEmpty { get; }
        public Tile Tile { get; }

        public DepositMetadata(EntityId entityId, Tile tile)
        {
            EntityId = entityId;
            IsEmpty = String.IsNullOrEmpty(entityId.Value);
            Tile = tile;
        }

        public static DepositMetadata Empty => new DepositMetadata(new EntityId(EntityClass.Deposit, null), null);
    }
}
