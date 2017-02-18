using UnforgottenRealms.Common.Resources;

namespace UnforgottenRealms.Game.Graphics
{
    public class GameTilesets : IResource
    {
        public ImprovementsTileset Improvements { get; private set; }
        public MiscellaneousTileset Miscellaneous { get; private set; }
        public TerrainTileset Terrain { get; private set; }
        public UnitsTileset Units { get; set; }

        public GameTilesets()
        {
            Miscellaneous = new MiscellaneousTileset(FilePath("misc"));
            Terrain = new TerrainTileset(FilePath("fields"));
            Units = new UnitsTileset(FilePath("units"));
            Improvements = new ImprovementsTileset(FilePath("imps"));
        }

        private string FilePath(string fileName) => $".\\gfx\\{fileName}.png";
    }
}
