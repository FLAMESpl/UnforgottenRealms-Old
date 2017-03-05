using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Level.Entities.Metadata;

namespace UnforgottenRealms.Editor.Palette
{
    public class TerrainBrush : Brush
    {
        public TerrainBrush(TerrainMetadata metadata) : base(metadata)
        {
        }

        public override void Paint(Field field) => field.Create((TerrainMetadata)EntityMetadata);
    }
}
