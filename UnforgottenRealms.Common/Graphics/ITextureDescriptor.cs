using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public interface ITextureDescriptor
    {
        Texture Texture { get; }
        Vector2i TileSize { get; }
    }
}
