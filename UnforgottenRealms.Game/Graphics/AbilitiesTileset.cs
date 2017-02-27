using SFML.Window;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.Graphics
{
    public class AbilitiesTileset : Tileset
    {
        public AbilitiesTileset(string path) : base(path, new Vector2i(64, 64))
        {
        }

        public Tile RangedAttack => Get(5);
    }
}
