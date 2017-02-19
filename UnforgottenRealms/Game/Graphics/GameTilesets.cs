using UnforgottenRealms.Common.Resources;

namespace UnforgottenRealms.Game.Graphics
{
    public class GameTilesets : IResource
    {
        public GuiTileset Gui { get; }
        public ImprovementsTileset Improvements { get; }
        public MiscellaneousTileset Miscellaneous { get; }
        public TerrainTileset Terrain { get; }
        public UnitsTileset Units { get; }

        public GameTilesets()
        {
            Gui = new GuiTileset(FilePath("gui"));
            Miscellaneous = new MiscellaneousTileset(FilePath("misc"));
            Terrain = new TerrainTileset(FilePath("fields"));
            Units = new UnitsTileset(FilePath("units"));
            Improvements = new ImprovementsTileset(FilePath("imps"));
        }

        private string FilePath(string fileName) => $".\\gfx\\{fileName}.png";
    }
}
