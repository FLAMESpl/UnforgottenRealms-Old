using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class UnitsTileset : Tileset
    {
        public UnitsTileset(string path) : base(path, new Vector2i(20, 20))
        {
        }

        public Tile Archer => Get(0);
        public Tile Swordsman => Get(1);
        public Tile Worker => Get(2);
        public Tile Ship => Get(3);
        public Tile Horseman => Get(4);
        public Tile Dragon => Get(5);
    }
}

