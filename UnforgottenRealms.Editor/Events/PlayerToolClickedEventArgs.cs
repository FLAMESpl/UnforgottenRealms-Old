using System;
using UnforgottenRealms.Common.Enums;

namespace UnforgottenRealms.Editor.Events
{
    public class PlayerSelectedEventArgs : EventArgs
    {
        public PlayerColour Colour { get; }

        public PlayerSelectedEventArgs(PlayerColour colour)
        {
            Colour = colour;
        }
    }
}
