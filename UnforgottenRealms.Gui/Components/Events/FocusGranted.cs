using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.Events
{
    public class FocusGranted : IEvent
    {
        public IComponent Target { get; set; }
    }
}
