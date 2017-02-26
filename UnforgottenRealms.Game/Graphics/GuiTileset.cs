using SFML.Window;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.Graphics
{
    public class GuiTileset : Tileset
    {
        public GuiTileset(string path) : base(path, new Vector2i(64, 64))
        {
        }

        public Tile Food => Get(0);
        public Tile Wood => Get(1);
        public Tile Iron => Get(2);
        public Tile Gems => Get(3);
        public Tile Grid => Get(4);
    }
}
