using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class TerrainMetadata : IEntityMetadata
    {
        public bool IsEmpty { get; }
        public EntityId? EntityId { get; }
        public TextureTile TextureDescriptor { get; }

        public TerrainMetadata(EntityId? entityId, TextureTile textureDescriptor)
        {
            IsEmpty = entityId == null;
            EntityId = entityId;
            TextureDescriptor = textureDescriptor;
        }

        public static TerrainMetadata Empty => new TerrainMetadata(null, null);
    }
}
