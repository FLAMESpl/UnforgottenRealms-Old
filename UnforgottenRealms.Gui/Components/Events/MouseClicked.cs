using SFML.Window;
using System;
using UnforgottenRealms.Common.Messaging;

namespace UnforgottenRealms.Gui.Components.Events
{
    public class MouseClicked : IEvent
    {
        public MouseButtonEventArgs Mouse { get; set; }
    }
}
