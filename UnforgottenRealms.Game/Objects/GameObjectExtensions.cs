using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Common.Geometry;
using UnforgottenRealms.Common.Geometry.Coordinates;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects
{
    public static class GameObjectExtensions
    {
        public static Vector2f Scale(this TileBase texture, Vector2f template)
        {
            return new Vector2f(template.X / texture.TileSize.X, template.Y / texture.TileSize.Y);
        }

        public static Unit StrongestOpponent(this IEnumerable<Unit> units, Unit attacker)
        {
            return units.MaxBy(u => u.EffectiveStrengthAgainst(attacker));
        }

        public static bool ContainsOpponent(this Field field, GameObject comparedObject)
        {
            return field.Units.Any(u => u.Owner != comparedObject.Owner);
        }

        public static void CreateHexOutline(this VertexArray vertexArray, AxialCoordinates position, HexModel model, Color color)
        {
            var topLeftCorner = model.GetTopLeftCorner(position);
            var apexes = model.GetApexesPositions(topLeftCorner);

            foreach (var apex in apexes)
            {
                vertexArray.Append(new Vertex(
                    position: apex,
                    color: color
                ));
            }

            vertexArray.Append(new Vertex(
                position: apexes[0],
                color: color
            ));
        }
    }
}
