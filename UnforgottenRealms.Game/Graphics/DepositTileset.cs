using SFML.Window;

namespace UnforgottenRealms.Game.Graphics
{
    public class DepositTileset : Tileset
    {
        public DepositTileset(string path) : base(path, new Vector2i(40, 40))
        {
        }

        public TextureDescriptor Iron => Get(0);
        public TextureDescriptor Gems => Get(1);
        public TextureDescriptor Pearls => Get(2);
    }
}
