using SFML.Window;
using UnforgottenRealms.Common;
using UnforgottenRealms.Game.Objects;

namespace UnforgottenRealms.Game.Actions
{
    public abstract class ActionResolver
    {
        protected AtomicReference<ActionResolver> activeActionResolver;
        protected AtomicReference<GameObject> selectedObject;

        public ActionResolver(AtomicReference<ActionResolver> activeActionResolver, AtomicReference<GameObject> selectedObject)
        {
            this.activeActionResolver = activeActionResolver;
            this.selectedObject = selectedObject;
        }

        public abstract void MousePressed(MouseButtonEventArgs eventArgs);
    }
}
