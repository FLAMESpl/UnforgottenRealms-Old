using SFML.Window;
using UnforgottenRealms.Common;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.Views;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Actions
{
    public class ActionController
    {
        private AtomicReference<ActionResolver> activeActionResolver;
        private AtomicReference<GameObject> selectedObject;
        private GameWindow window;

        public ActionController(GameWindow window, Map worldMap, TurnCycle turnCycle, WorldView worldView)
        {
            this.window = window;
            this.selectedObject = new AtomicReference<GameObject>();
            this.activeActionResolver = new AtomicReference<ActionResolver>(new IdleActionResolver(
                activeActionResolver: activeActionResolver, 
                selectedObject: selectedObject,
                worldMap: worldMap, 
                worldView: worldView));

            window.MouseButtonPressed += MouseButtonPressed;
            turnCycle.TurnChanged += TurnChanged;
        }

        public void MouseButtonPressed(object sender, MouseButtonEventArgs e) => activeActionResolver.Value?.MousePressed(e);
        public void TurnChanged(object sender, ValueChangedEventArgs<Player> e) => activeActionResolver.Value?.TurnChanged(e);
    }
}
