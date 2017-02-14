using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrain
{
    public class Grass : Field
    {
        public Grass(OffsetCoordinates position, HexModel model)
        {
            Position = position;

            var topLeftCorner = new Vector2f(
                position.Column * model.HorizontalSize + (model.HorizontalSize * 0.5f * (position.Row & 1)),
                position.Row * (model.VerticalSize - model.EdgeLength / 2)
            );

            var color = Color.Red;
            var apexes = model.GetApexesPositions(topLeftCorner);

            vertex = new VertexArray(PrimitiveType.LinesStrip);
            var center = model.GetCenter(topLeftCorner);
            vertex.Append(new Vertex(center, color));
            for (uint i = 0; i < 6; i++)
            {
                vertex.Append(new Vertex(apexes[i], color));
            }
            vertex.Append(new Vertex(apexes[0], color));
        }
    }
}
