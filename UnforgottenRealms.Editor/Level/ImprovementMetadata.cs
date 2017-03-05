using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class ImprovementMetadata : IEntityMetadata
    {
        public EntityId EntityId { get; }
        public bool IsEmpty { get; }
        public PlayerColour? Owner { set; get; }
        public Tile Tile { get; set; }

        public ImprovementMetadata(EntityId entityId, PlayerColour? owner, Tile tile)
        {
            EntityId = entityId;
            IsEmpty = entityId.Value == null;
            Owner = owner;
            Tile = tile;
        }

        public static ImprovementMetadata Empty => new ImprovementMetadata(new EntityId(EntityClass.Improvement, null), null, null);
    }
}
