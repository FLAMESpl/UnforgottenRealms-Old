using SFML.Window;
using UnforgottenRealms.Common;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;

namespace UnforgottenRealms.Game.Actions
{
    public abstract class ActionResolver
    {
        protected AtomicReference<ActionResolver> activeActionResolver;
        protected AtomicReference<ActionResolverFactories> actionResolverFactories;

        public ActionResolver(
            AtomicReference<ActionResolver> activeActionResolver, 
            AtomicReference<ActionResolverFactories> actionResolverFactories)
        {
            this.activeActionResolver = activeActionResolver;
            this.actionResolverFactories = actionResolverFactories;
        }

        public virtual void MousePressed(MouseButtonEventArgs eventArgs) { }
        public virtual void TurnChanged(ValueChangedEventArgs<Player> eventArgs) { }
    }
}
