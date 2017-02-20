namespace UnforgottenRealms.Game.Graphics
{
    public class MiscellaneousTileset : Tileset
    {
        public MiscellaneousTileset(string path) : base(path, new SFML.Window.Vector2i(40, 40))
        {
        }

        public TextureDescriptor Emblem => Get(0);
        public TextureDescriptor Flag => Get(1);
    }
}
