using SFML.Window;
using System;
using UnforgottenRealms.Common.Messaging;

namespace UnforgottenRealms.Gui.Components.Events
{
    public class MouseMoved : IEvent
    {
        public MouseMoveEventArgs Mouse { get; set; }
    }
}
