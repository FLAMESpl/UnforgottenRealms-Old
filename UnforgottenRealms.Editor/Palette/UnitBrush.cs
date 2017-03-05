using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Level.Entities.Metadata;

namespace UnforgottenRealms.Editor.Palette
{
    public class UnitBrush : Brush
    {
        public UnitBrush(UnitMetadata metadata) : base(metadata)
        {
        }

        public override void Paint(Field field) => field.Create((UnitMetadata)EntityMetadata);

        public void ChangePlayer(PlayerColour player)
        {
            ((UnitMetadata)EntityMetadata).Owner = player;
        }
    }
}
