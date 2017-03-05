using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Editor.Level;

namespace UnforgottenRealms.Editor.Palette
{
    public class ImprovementBrush : Brush
    {
        public ImprovementBrush(ImprovementMetadata metadata) : base(metadata)
        {
        }

        public void ChangePlayer(PlayerColour colour) => ((ImprovementMetadata)EntityMetadata).Owner = colour;

        public override void Paint(Field field) => field.Create((ImprovementMetadata)EntityMetadata);
    }
}
