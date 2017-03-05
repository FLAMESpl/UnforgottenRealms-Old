namespace UnforgottenRealms.Common.Graphics
{
    public class MiscellaneousTileset : Tileset
    {
        public MiscellaneousTileset(string path) : base(path, new SFML.Window.Vector2i(40, 40))
        {
        }

        public Tile Emblem => Get(0);
        public Tile Flag => Get(1);
    }
}
