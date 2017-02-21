using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Editor.Graphics
{
    public class EditorTilesets : IResource
    {
        public DepositTileset Deposits { get; set; }
        public ImprovementsTileset Improvements { get; set; }
        public TerrainTileset Terrain { get; set; }
        public UnitsTileset Units { get; set; }

        public EditorTilesets()
        {
            Deposits = new DepositTileset("deps");
            Improvements = new ImprovementsTileset("imps");
            Terrain = new TerrainTileset("terrain");
            Units = new UnitsTileset("units");
        }

        private string GetPath(string fileName) => $".\\gfx\\{fileName}.png";
    }
}
