using UnforgottenRealms.Game.Objects.Improvements;
using UnforgottenRealms.Game.Objects.Units;

namespace UnforgottenRealms.Game.World
{
    public static class FieldExtensions
    {
        public static void Destroy(this Unit unit) => unit.Location.Destroy(unit);
        public static void Destroy(this Improvement improvement) => improvement.Location.Destroy();
    }
}
