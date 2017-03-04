using System.Drawing;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Utils;

namespace UnforgottenRealms.Editor.Helpers
{
    public static class ColorExtensions
    {
        public static Color ToSystemActiveColor(this PlayerColour colour)
        {
            var rgb = colour.ToRGB();
            return Color.FromArgb(rgb.A, rgb.R, rgb.G, rgb.B);
        }

        public static Color ToSystemInactiveColor(this PlayerColour colour)
        {
            var rgb = colour.ToRGB();
            return Color.FromArgb(rgb.A - 155, rgb.R, rgb.G, rgb.B);
        }
    }
}
