using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Objects.Units;

namespace UnforgottenRealms.Game.Objects
{
    public static class GameObjectExtensions
    {
        public static Vector2f Scale(this ITile texture, Vector2f template)
        {
            return new Vector2f(template.X / texture.TileSize.X, template.Y / texture.TileSize.Y);
        }

        public static Unit StrongestOpponent(this IEnumerable<Unit> units, Unit attacker)
        {
            return units.MaxBy(u => u.EffectiveStrengthAgainst(attacker));
        }
    }
}
