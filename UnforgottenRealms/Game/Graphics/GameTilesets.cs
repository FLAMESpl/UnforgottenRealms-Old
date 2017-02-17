using System;
using UnforgottenRealms.Common.Resources;

namespace UnforgottenRealms.Game.Graphics
{
    public class GameTilesets : IResource
    {
        public MiscellaneousTileset Miscellaneous { get; private set; }
        public TerrainTileset Terrain { get; private set; }
        public UnitsTileset Units { get; set; }

        public GameTilesets()
        {
            Func<string, string> pathProvider = s => $".\\gfx\\{s}.png";

            Miscellaneous = new MiscellaneousTileset(pathProvider("misc"));
            Terrain = new TerrainTileset(pathProvider("fields"));
            Units = new UnitsTileset(pathProvider("units"));
        }
    }
}
