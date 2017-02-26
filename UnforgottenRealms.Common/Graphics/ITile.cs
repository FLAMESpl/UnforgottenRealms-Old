using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public interface ITile
    {
        Texture Texture { get; }
        Vector2i TileSize { get; }
    }
}
