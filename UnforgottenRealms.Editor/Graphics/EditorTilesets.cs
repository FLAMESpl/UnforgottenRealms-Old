using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Common.Resources;

namespace UnforgottenRealms.Editor.Graphics
{
    public class EditorTilesets : IResource
    {
        public DepositTileset Deposits { get; set; }
        public ImprovementsTileset Improvements { get; set; }
        public MiscellaneousTileset Miscellaneous { get; set; }
        public TerrainTileset Terrain { get; set; }
        public UnitsTileset Units { get; set; }

        public EditorTilesets()
        {
            Deposits = new DepositTileset(GetPath("deps"));
            Improvements = new ImprovementsTileset(GetPath("imps"));
            Miscellaneous = new MiscellaneousTileset(GetPath("misc"));
            Terrain = new TerrainTileset(GetPath("terrain"));
            Units = new UnitsTileset(GetPath("units"));
        }

        private string GetPath(string fileName) => $".\\gfx\\{fileName}.png";
    }
}
