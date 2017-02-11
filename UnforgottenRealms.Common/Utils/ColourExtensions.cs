using SFML.Graphics;
using System;
using UnforgottenRealms.Common.Enums;

namespace UnforgottenRealms.Common.Utils
{
    public static class ColourExtensions
    {
        private static readonly PlayerColour[] playerColours = (PlayerColour[])Enum.GetValues(typeof(PlayerColour));

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

        public static PlayerColour Next(this PlayerColour colour)
        {
            int size = playerColours.Length;
            int position = (int)colour;
            if (size > position)
                return (PlayerColour)(position + 1);
            else
                return 0;
        }

        public static PlayerColour Prev(this PlayerColour colour)
        {
            int size = playerColours.Length;
            int position = (int)colour;
            if (position == 0)
                return (PlayerColour)(size - 1);
            else
                return (PlayerColour)(position - 1);
        }
    }
}
