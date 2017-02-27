using SFML.Window;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Common;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.Views;
using System.Linq;

namespace UnforgottenRealms.Game.Actions
{
    public class ObjectActionResolver : ActionResolver
    {
        private Map worldMap;
        private WorldView worldView;
        private GameObject selectedObject;

        public ObjectActionResolver(
            AtomicReference<ActionResolver> activeActionResolver,
            AtomicReference<ActionResolverFactories> actionResolverFactories,
            GameObject selectedObject, 
            Map worldMap, 
            WorldView worldView) : base(
                activeActionResolver: activeActionResolver,
                actionResolverFactories: actionResolverFactories
            )
        {
            this.worldMap = worldMap;
            this.worldView = worldView;
            this.selectedObject = selectedObject;
        }

        public override void MousePressed(MouseButtonEventArgs eventArgs)
        {
            var mousePosition = worldView.MapMousePosition(new Vector2f(eventArgs.X, eventArgs.Y));
            var position = worldMap.Find(mousePosition);
            if (position != null)
            {
                if (position.IsEqualTo(selectedObject.Location.Position))
                {
                    if (eventArgs.Button == Mouse.Button.Left)
                    {
                        selectedObject.Select(false);
                        selectedObject.Location.CycleUnits();
                        selectedObject = selectedObject.Location.Units.LastOrDefault() ?? selectedObject;
                        selectedObject.Select(true);
                    }
                    else if (eventArgs.Button == Mouse.Button.Right)
                    {
                        var improvement = selectedObject.Location.Improvement;
                        if (improvement != null)
                        {
                            selectedObject.Select(false);
                            selectedObject = improvement;
                            selectedObject.Select(true);
                        }
                    }
                }
                else
                {
                    if (eventArgs.Button == Mouse.Button.Left)
                        DeselectObject();
                    else if (eventArgs.Button == Mouse.Button.Right)
                        selectedObject.PerformPrimaryAction(worldMap[position]);
                }
            }
        }

        public override void TurnChanged(ValueChangedEventArgs<Player> eventArgs)
        {
            DeselectObject();
        }

        private void DeselectObject()
        {
            selectedObject.Select(false);
            activeActionResolver.Value = actionResolverFactories.Value.IdleAction.Invoke();
        }
    }
}
