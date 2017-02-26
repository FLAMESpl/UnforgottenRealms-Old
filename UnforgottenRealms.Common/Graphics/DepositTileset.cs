using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class DepositTileset : Tileset
    {
        public DepositTileset(string path) : base(path, new Vector2i(40, 40))
        {
        }

        public Tile Iron => Get(0);
        public Tile Gems => Get(1);
        public Tile Pearls => Get(2);
    }
}
