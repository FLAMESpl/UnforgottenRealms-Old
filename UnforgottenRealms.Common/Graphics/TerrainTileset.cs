using SFML.Window;
using UnforgottenRealms.Common.Geometry;

namespace UnforgottenRealms.Common.Graphics
{
    public class TerrainTileset : Tileset
    {
        private HexModel maskModel;

        public TerrainTileset(string path) : base(path, new Vector2i(40, 40))
        {
            maskModel = new HexModel(tileSize.X / 2);
        }

        public new TerrainTile Get(int index)
        {
            var row = index / tileCountPerRow;
            var rowIndex = index % tileCountPerRow;
            var left = rowIndex * tileSize.X;
            var top = row * tileSize.Y;
            var leftTop = new Vector2f(left, top);
            leftTop.X += (maskModel.EdgeLength * 2 - maskModel.HorizontalSize) / 2;
            return new TerrainTile(
                apexes: maskModel.GetApexesPositions(leftTop),
                center: maskModel.GetCenter(leftTop),
                texture: Texture,
                tileSize: tileSize
            );
        }

        public TerrainTile Grass => Get(0);
        public TerrainTile Desert => Get(1);
        public TerrainTile Water => Get(2);
        public TerrainTile Mountain => Get(3);
        public TerrainTile Hill => Get(4);
        public TerrainTile Forest => Get(5);
    }
}
