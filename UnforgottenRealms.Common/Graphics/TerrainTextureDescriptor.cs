using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class TerrainTextureDescriptor : ITextureDescriptor
    {
        public Vector2f[] Apexes { get; }
        public Vector2f Center { get; set; }
        public Texture Texture { get; }
        public Vector2i TileSize { get; }

        public TerrainTextureDescriptor(Vector2f[] apexes, Vector2f center, Texture texture, Vector2i tileSize)
        {
            Apexes = apexes;
            Center = center;
            Texture = texture;
            TileSize = tileSize;
        }
    }
}
