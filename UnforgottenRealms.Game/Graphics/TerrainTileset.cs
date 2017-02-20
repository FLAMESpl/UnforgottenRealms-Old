using SFML.Window;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Graphics
{
    public class TerrainTileset : Tileset
    {
        private HexModel maskModel;

        public TerrainTileset(string path) : base(path, new Vector2i(40, 40))
        {
            maskModel = new HexModel(tileSize.X / 2);
        }

        public new TerrainTextureDescriptor Get(int index)
        {
            var row = index / tileCountPerRow;
            var rowIndex = index % tileCountPerRow;
            var left = rowIndex * tileSize.X;
            var top = row * tileSize.Y;
            var leftTop = new Vector2f(left, top);
            return new TerrainTextureDescriptor(
                apexes: maskModel.GetApexesPositions(leftTop),
                center: maskModel.GetCenter(leftTop),
                texture: Texture,
                tileSize: tileSize
            );
        }

        public TerrainTextureDescriptor Grass => Get(0);
        public TerrainTextureDescriptor Desert => Get(1);
        public TerrainTextureDescriptor Water => Get(2);
        public TerrainTextureDescriptor Mountain => Get(3);
        public TerrainTextureDescriptor Hill => Get(4);
        public TerrainTextureDescriptor Forest => Get(5);
    }
}
