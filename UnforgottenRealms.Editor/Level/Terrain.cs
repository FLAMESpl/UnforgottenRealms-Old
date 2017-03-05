using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public class Terrain : ITerrain, Drawable
    {
        private Color nullTextureColor = new Color(50, 50, 200);
        private Texture texture;
        private VertexArray vertex;

        public EntityId Id { get; }
        public TerrainMetadata Metadata { get; }

        public Terrain(Field location, TerrainMetadata metadata)
        {
            Id = metadata.EntityId;
            Metadata = metadata;
            texture = metadata.TextureDescriptor?.Texture;

            InitializeVertex(location);
        }

        protected virtual void InitializeVertex(Field location)
        {
            var model = location.World.Model;
            var topLeftCorner = model.GetTopLeftCorner(location.Position);

            var apexes = model.GetApexesPositions(topLeftCorner);
            var hexCenter = model.GetCenter(topLeftCorner);

            vertex = new VertexArray(PrimitiveType.TrianglesFan);

            if (Metadata.IsEmpty)
                CreateVertexWithoutTexture(apexes, hexCenter);
            else
                CreateVertexWithTexture(apexes, hexCenter);
        }

        private void CreateVertexWithTexture(Vector2f[] apexes, Vector2f center)
        {
            vertex.Append(new Vertex(center, Metadata.TextureDescriptor.Center));
            for (uint i = 0; i < 6; i++)
            {
                vertex.Append(new Vertex(apexes[i], Metadata.TextureDescriptor.Apexes[i]));
            }
            vertex.Append(new Vertex(apexes[0], Metadata.TextureDescriptor.Apexes[0]));
        }

        private void CreateVertexWithoutTexture(Vector2f[] apexes, Vector2f center)
        {
            vertex.Append(new Vertex(center, nullTextureColor));
            for (uint i = 0; i < 6; i++)
            {
                vertex.Append(new Vertex(apexes[i], nullTextureColor));
            }
            vertex.Append(new Vertex(apexes[0], nullTextureColor));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            target.Draw(vertex, states);
        }
    }
}
