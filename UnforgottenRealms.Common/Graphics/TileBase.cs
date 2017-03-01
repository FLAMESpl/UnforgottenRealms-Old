using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public abstract class TileBase
    {
        public Texture Texture { get; }
        public Vector2i TileSize { get; }

        public TileBase(Texture texture, Vector2i tileSize)
        {
            Texture = texture;
            TileSize = tileSize;
        }

        public Vector2f Scale(Vector2f template)
        {
            return new Vector2f(template.X / TileSize.X, template.Y / TileSize.Y);
        }
    }
}
