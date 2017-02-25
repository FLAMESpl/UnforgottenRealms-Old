using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class TerrainMetadata : IEntityMetadata
    {
        public bool IsEmpty { get; }
        public EntityId? EntityId { get; }
        public TerrainTextureDescriptor TextureDescriptor { get; }

        public TerrainMetadata(EntityId? entityId, TerrainTextureDescriptor textureDescriptor)
        {
            IsEmpty = entityId == null;
            EntityId = entityId;
            TextureDescriptor = textureDescriptor;
        }

        public static TerrainMetadata Empty => new TerrainMetadata(null, null);
    }
}
