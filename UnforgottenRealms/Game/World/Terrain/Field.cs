using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrain
{
    public abstract class Field : Drawable
    {
        protected VertexArray vertex;
        private Texture texture;

        public int MovementCost { get; }
        public AxialCoordinates Position { get; }
        public TerrainType Type { get; }
        public IList<Unit> Units { get; }

        public Field(OffsetCoordinates position, HexModel model, TerrainTextureDescriptor textureDescriptor, int movementCost, TerrainType type)
        {
            MovementCost = movementCost;
            Position = position;
            Type = type;
            if (this is Water)
                ;
            if (this is Desert)
                ;
            texture = textureDescriptor.Texture;
            InitializeVertex(position, model, textureDescriptor);
            Units = new List<Unit>();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            target.Draw(vertex, states);

            var unit = Units.LastOrDefault();
            if (unit != null)
                target.Draw(unit, states);
        }

        private void InitializeVertex(OffsetCoordinates position, HexModel model, TerrainTextureDescriptor textureDescriptor)
        {
            var topLeftCorner = new Vector2f(
                position.Column * model.HorizontalSize + (model.HorizontalSize* 0.5f * (position.Row & 1)),
                position.Row * (model.VerticalSize - model.EdgeLength / 2)
            );
            
            var apexes = model.GetApexesPositions(topLeftCorner);
            var hexCenter = model.GetCenter(topLeftCorner);

            vertex = new VertexArray(PrimitiveType.TrianglesFan);

            vertex.Append(new Vertex(hexCenter, textureDescriptor.Center));
            for (uint i = 0; i<  6; i++)
            {
                vertex.Append(new Vertex(apexes[i], textureDescriptor.Apexes[i]));
            }
            vertex.Append(new Vertex(apexes[0], textureDescriptor.Apexes[0]));
        }
    }
}
