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

        public new TextureTile Get(int index)
        {
            var row = index / tileCountPerRow;
            var rowIndex = index % tileCountPerRow;
            var left = rowIndex * tileSize.X;
            var top = row * tileSize.Y;
            var leftTop = new Vector2f(left, top);
            leftTop.X += (maskModel.EdgeLength * 2 - maskModel.HorizontalSize) / 2;
            return new TextureTile(
                apexes: maskModel.GetApexesPositions(leftTop),
                center: maskModel.GetCenter(leftTop),
                texture: Texture,
                tileSize: tileSize
            );
        }

        public TextureTile Grass => Get(0);
        public TextureTile Desert => Get(1);
        public TextureTile Water => Get(2);
        public TextureTile Mountain => Get(3);
        public TextureTile Hill => Get(4);
        public TextureTile Forest => Get(5);
    }
}
