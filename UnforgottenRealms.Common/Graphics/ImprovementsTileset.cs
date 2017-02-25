using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class ImprovementsTileset : Tileset
    {
        public ImprovementsTileset(string path) : base(path, new Vector2i(40, 40))
        {
        }

        public TextureDescriptor Farm => Get(0);
        public TextureDescriptor Barracks => Get(1);
        public TextureDescriptor LumberjacksHut => Get(2);
        public TextureDescriptor IronMine => Get(3);
        public TextureDescriptor GemsMine => Get(4);
        public TextureDescriptor Stable => Get(5);
        public TextureDescriptor Shipyard => Get(6);
        public TextureDescriptor DragonLair => Get(7);
    }
}
