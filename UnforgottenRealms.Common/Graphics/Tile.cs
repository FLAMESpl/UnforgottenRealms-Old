using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class Tile : TileBase
    {
        public IntRect Bounds { get; private set; }

        public Tile(IntRect bounds, Texture texture, Vector2i tileSize) : base(texture, tileSize)
        {
            Bounds = bounds;
        }
    }
}
