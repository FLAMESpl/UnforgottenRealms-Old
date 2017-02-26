using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class Tileset
    {
        protected Vector2i tileSize;
        protected int tileCountPerRow;

        public Texture Texture { get; }

        public Tileset(string path, Vector2i tileSize)
        {
            this.tileSize = tileSize;
            Texture = new Texture(path);
            tileCountPerRow = (int)Texture.Size.X / tileSize.X;
        }

        public Tile Get(int index)
        {
            var row = index / tileCountPerRow;
            var rowIndex = index % tileCountPerRow;
            var left = rowIndex * tileSize.X;
            var top = row * tileSize.Y;
            return new Tile(
                bounds: new IntRect(left, top, tileSize.X, tileSize.Y),
                texture: Texture,
                tileSize: tileSize
            );
        }
    }
}
