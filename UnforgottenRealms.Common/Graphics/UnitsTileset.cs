using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class UnitsTileset : Tileset
    {
        public UnitsTileset(string path) : base(path, new Vector2i(20, 20))
        {
        }

        public TextureDescriptor Archer => Get(0);
        public TextureDescriptor Swordsman => Get(1);
        public TextureDescriptor Worker => Get(2);
        public TextureDescriptor Ship => Get(3);
        public TextureDescriptor Horseman => Get(4);
        public TextureDescriptor Dragon => Get(5);
    }
}

