using SFML.Graphics;
using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public delegate Terrain TerrainFactory(Field location);

    public abstract class Terrain : Drawable
    {
        protected VertexArray vertex;
        private Texture texture;

        public Field Location { get; }

        public abstract int MovementCost { get; }
        public abstract TerrainType Type { get; }

        public Terrain(Field location, TerrainTextureDescriptor textureDescriptor)
        {
            Location = location;
            texture = textureDescriptor.Texture;
            InitializeVertex(textureDescriptor);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            target.Draw(vertex, states);
        }

        private void InitializeVertex(TerrainTextureDescriptor textureDescriptor)
        {
            var model = Location.World.Model;
            var topLeftCorner = model.GetTopLeftCorner(Location.Position);
            /*var topLeftCorner = new Vector2f(
                position.Column * model.HorizontalSize + (model.HorizontalSize* 0.5f * (position.Row & 1)),
                position.Row * (model.VerticalSize - model.EdgeLength / 2)
            );*/
            
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
