using System;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Events
{
    public class PaletteToolClickedEventArgs : EventArgs
    {
        public PaletteType PaletteType { get; }

        public PaletteToolClickedEventArgs(PaletteType type)
        {
            PaletteType = type;
        }
    }
}
