using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class ImprovementsTileset : Tileset
    {
        public ImprovementsTileset(string path) : base(path, new Vector2i(40, 40))
        {
        }

        public Tile Farm => Get(0);
        public Tile Barracks => Get(1);
        public Tile LumberjacksHut => Get(2);
        public Tile IronMine => Get(3);
        public Tile GemsMine => Get(4);
        public Tile Stable => Get(5);
        public Tile Shipyard => Get(6);
        public Tile DragonLair => Get(7);
    }
}
