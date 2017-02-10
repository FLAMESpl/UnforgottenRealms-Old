using SFML.Graphics;
using UnforgottenRealms.Common.Enums;

namespace UnforgottenRealms.Common.Utils
{
    public static class ColourExtensions
    {
        public static bool ValueEquals(this Color obj, Color other)
        {
            return obj.A == other.A
                && obj.B == other.B
                && obj.G == other.G
                && obj.R == other.R;
        }

        public static Color ToRGB(this PlayerColour colour)
        {
            switch (colour)
            {
                case PlayerColour.Red:
                    return Color.Red;
                case PlayerColour.Blue:
                    return Color.Blue;
                case PlayerColour.Yellow:
                    return Color.Yellow;
                case PlayerColour.Green:
                    return Color.Green;
                default:
                    return Color.Transparent;
            }
        }
    }
}
