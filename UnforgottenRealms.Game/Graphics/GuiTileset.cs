using SFML.Window;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.Graphics
{
    public class GuiTileset : Tileset
    {
        public GuiTileset(string path) : base(path, new Vector2i(64, 64))
        {
        }

        public TextureDescriptor Food => Get(0);
        public TextureDescriptor Wood => Get(1);
        public TextureDescriptor Iron => Get(2);
        public TextureDescriptor Gems => Get(3);
        public TextureDescriptor Grid => Get(4);
    }
}
