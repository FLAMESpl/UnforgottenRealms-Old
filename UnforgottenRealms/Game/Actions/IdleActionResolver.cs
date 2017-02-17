using SFML.Window;
using System.Linq;
using UnforgottenRealms.Common;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Views;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;

namespace UnforgottenRealms.Game.Actions
{
    public class IdleActionResolver : ActionResolver
    {
        private Map worldMap;
        private WorldView worldView;

        public IdleActionResolver(AtomicReference<ActionResolver> activeActionResolver, AtomicReference<GameObject> selectedObject, Map worldMap, WorldView worldView) : 
            base(activeActionResolver, selectedObject)
        {
            this.worldMap = worldMap;
            this.worldView = worldView;
        }

        public override void MousePressed(MouseButtonEventArgs eventArgs)
        {
            var mousePosition = worldView.MapMousePosition(new Vector2f(eventArgs.X, eventArgs.Y));
            var position = worldMap.Find(mousePosition);
            if (position != null)
            {
                var newObject = worldMap[position].Units.FirstOrDefault();
                selectedObject.Value?.Select(false);

                if (newObject != null && !newObject.Owner.Active)
                {
                    newObject = null;
                }

                selectedObject.Value = newObject;
                newObject?.Select(true);
            }
        }

        public override void TurnChanged(ValueChangedEventArgs<Player> eventArgs)
        {
            selectedObject.Value?.Select(false);
        }
    }
}
