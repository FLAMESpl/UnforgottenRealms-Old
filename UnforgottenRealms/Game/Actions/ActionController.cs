using SFML.Window;
using UnforgottenRealms.Common;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Views;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Actions
{
    public class ActionController
    {
        private AtomicReference<ActionResolver> activeActionResolver;
        private AtomicReference<GameObject> selectedObject;
        private GameWindow window;

        public ActionController(GameWindow window, Map worldMap, WorldView worldView)
        {
            this.window = window;
            this.selectedObject = new AtomicReference<GameObject>();
            this.activeActionResolver = new AtomicReference<ActionResolver>(new IdleActionResolver(
                activeActionResolver: activeActionResolver, 
                selectedObject: selectedObject,
                worldMap: worldMap, 
                worldView: worldView));

            window.MouseButtonPressed += MouseButtonPressed;
        }

        public void MouseButtonPressed(object sender, MouseButtonEventArgs e) => activeActionResolver.Value?.MousePressed(e);
    }
}
