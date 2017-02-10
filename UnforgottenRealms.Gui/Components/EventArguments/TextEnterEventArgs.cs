using System;

namespace UnforgottenRealms.Gui.Components.EventArguments
{
    public class TextEnterEventArgs : EventArgs
    {
        public string OldText { get; set; }
        public string NewText { get; set; }
    }
}
