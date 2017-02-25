using System.Drawing;

namespace UnforgottenRealms.Editor.Palette
{
    public class ImageBrushPair
    {
        public Brush Brush { get; }
        public Image Image { get; }

        public ImageBrushPair(Brush brush, Image image)
        {
            Brush = brush;
            Image = image;
        }
    }
}
