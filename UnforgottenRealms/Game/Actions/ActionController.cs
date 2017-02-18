using SFML.Window;
using UnforgottenRealms.Common;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.Views;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Actions
{
    public class ActionController
    {
        private AtomicReference<ActionResolverFactories> factories;
        private AtomicReference<ActionResolver> activeActionResolver;
        private GameWindow window;

        public ActionController(GameWindow window, Map worldMap, TurnCycle turnCycle, WorldView worldView)
        {
            this.window = window;
            this.factories = new AtomicReference<ActionResolverFactories>();
            this.activeActionResolver = new AtomicReference<ActionResolver>();

            this.factories.Value = new ActionResolverFactories(
                idleActionResolverFactory: () => new IdleActionResolver(
                    activeActionResolver: activeActionResolver,
                    actionResolverFactories: factories,
                    worldMap: worldMap,
                    worldView: worldView
                ),
                objectActionResolverFactory: selectedObject => new ObjectActionResolver(
                    activeActionResolver: activeActionResolver,
                    actionResolverFactories: factories,
                    selectedObject: selectedObject,
                    worldMap: worldMap,
                    worldView: worldView
                )
            );

            this.activeActionResolver.Value = factories.Value.IdleAction.Invoke();

            window.MouseButtonPressed += MouseButtonPressed;
            turnCycle.TurnChanged += TurnChanged;
        }

        public void MouseButtonPressed(object sender, MouseButtonEventArgs e) => activeActionResolver.Value?.MousePressed(e);
        public void TurnChanged(object sender, ValueChangedEventArgs<Player> e) => activeActionResolver.Value?.TurnChanged(e);
    }
}
