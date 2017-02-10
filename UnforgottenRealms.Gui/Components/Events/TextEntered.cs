using SFML.Window;
using UnforgottenRealms.Common.Messaging;

namespace UnforgottenRealms.Gui.Components.Events
{
    public class TextEntered : IEvent
    {
        public static readonly char Backspace = '\b';
        public static readonly char CarriageReturn = '\r';

        public TextEventArgs Text { get; set; }

    }
}
