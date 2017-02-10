using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Gui.Components.Events;

namespace UnforgottenRealms.Gui.Components.Container
{
    public interface IComponentEventHandler :
        IEventHandler<MouseClicked>,
        IEventHandler<MouseMoved>,
        IEventHandler<TextEntered>
    {
    }
}
