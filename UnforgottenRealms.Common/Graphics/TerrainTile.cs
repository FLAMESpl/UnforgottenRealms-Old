using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class TerrainTile : TileBase
    {
        public Vector2f[] Apexes { get; }
        public Vector2f Center { get; set; }

        public TerrainTile(Vector2f[] apexes, Vector2f center, Texture texture, Vector2i tileSize) : base(texture, tileSize)
        {
            Apexes = apexes;
            Center = center;
        }
    }
}
