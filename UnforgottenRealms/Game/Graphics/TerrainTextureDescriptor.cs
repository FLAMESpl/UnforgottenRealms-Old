using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Game.Graphics
{
    public class TerrainTextureDescriptor
    {
        public Vector2f[] Apexes { get; }
        public Vector2f Center { get; set; }
        public Texture Texture { get; }

        public TerrainTextureDescriptor(Vector2f[] apexes, Vector2f center, Texture texture)
        {
            Apexes = apexes;
            Center = center;
            Texture = texture;
        }
    }
}
