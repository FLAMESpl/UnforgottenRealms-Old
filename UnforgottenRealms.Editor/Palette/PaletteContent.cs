using System.Collections.Generic;

namespace UnforgottenRealms.Editor.Palette
{
    public class PaletteContent
    {
        public IEnumerable<ImageBrushPair> Images { get; }
        public Probe Probe { get; }

        public PaletteContent(IEnumerable<ImageBrushPair> images, Probe probe)   
        {
            Images = images;
            Probe = probe;
        }
    }
}
