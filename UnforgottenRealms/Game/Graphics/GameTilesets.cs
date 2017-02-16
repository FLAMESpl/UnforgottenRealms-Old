using System;
using UnforgottenRealms.Common.Resources;

namespace UnforgottenRealms.Game.Graphics
{
    public class GameTilesets : IResource
    {
        public TerrainTileset Terrain { get; private set; }

        public GameTilesets()
        {
            Func<string, string> pathProvider = s => $".\\gfx\\{s}.png";
            Terrain = new TerrainTileset(pathProvider("fields"));
        }
    }
}
