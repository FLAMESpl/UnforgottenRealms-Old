using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrains
{
    public delegate Terrain TerrainFactory(Field location, HexModel model, ResourceManager resources);

    public abstract class Terrain : Drawable
    {
        protected VertexArray vertex;
        private Texture texture;

        public Field Location { get; }

        public int MovementCost { get; }
        public TerrainType Type { get; }

        public Terrain(Field location, HexModel model, TerrainTextureDescriptor textureDescriptor, int movementCost, TerrainType type)
        {
            MovementCost = movementCost;
            Location = location;
            Type = type;
            if (this is Water)
                ;
            if (this is Desert)
                ;
            texture = textureDescriptor.Texture;
            InitializeVertex(location.Position, model, textureDescriptor);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            target.Draw(vertex, states);
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
