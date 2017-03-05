using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class TerrainMetadata : IEntityMetadata
    {
        public bool IsEmpty { get; }
        public EntityId EntityId { get; }
        public TerrainTile TextureDescriptor { get; }

        public TerrainMetadata(EntityId entityId, TerrainTile textureDescriptor)
        {
            IsEmpty = entityId.Value == null;
            EntityId = entityId;
            TextureDescriptor = textureDescriptor;
        }

        public static TerrainMetadata Empty => new TerrainMetadata(new EntityId(EntityClass.Terrain, null), null);
    }
}
