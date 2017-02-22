using System.Drawing;
using System.Windows.Forms;

namespace UnforgottenRealms.Editor.Palette
{
    public class PaletteContent
    {
        public ImageList Images { get; }
        public Size Size { get; }

        public PaletteContent(ImageList images, Size size)
        {
            Images = images;
            Size = size;
        }
    }
}
