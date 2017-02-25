using SFML.Graphics;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Level
{
    public delegate Terrain TerrainFactory(Field location);

    public class Terrain : ITerrain, Drawable
    {
        private Texture texture;
        private VertexArray vertex;

        public TerrainMetadata Metadata { get; }

        public Terrain(Field location, TerrainMetadata metadata)
        {
            Metadata = metadata;
            texture = metadata.TextureDescriptor.Texture;

            var model = location.World.Model;
            var topLeftCorner = model.GetTopLeftCorner(location.Position);

            var apexes = model.GetApexesPositions(topLeftCorner);
            var hexCenter = model.GetCenter(topLeftCorner);

            vertex = new VertexArray(PrimitiveType.TrianglesFan);

            vertex.Append(new Vertex(hexCenter, metadata.TextureDescriptor.Center));
            for (uint i = 0; i < 6; i++)
            {
                vertex.Append(new Vertex(apexes[i], metadata.TextureDescriptor.Apexes[i]));
            }
            vertex.Append(new Vertex(apexes[0], metadata.TextureDescriptor.Apexes[0]));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            target.Draw(vertex, states);
        }
    }
}
