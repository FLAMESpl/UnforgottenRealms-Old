﻿using SFML.Window;
using System.Linq;
using UnforgottenRealms.Common;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Views;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Actions
{
    public class IdleActionResolver : ActionResolver
    {
        private Map worldMap;
        private WorldView worldView;

        public IdleActionResolver(
            AtomicReference<ActionResolver> activeActionResolver,
            AtomicReference<ActionResolverFactories> actionResolverFactories, 
            Map worldMap, 
            WorldView worldView) : base(
                activeActionResolver,
                actionResolverFactories
            )
        {
            this.worldMap = worldMap;
            this.worldView = worldView;
        }

        public override void MousePressed(MouseButtonEventArgs eventArgs)
        {
            if (eventArgs.Button != Mouse.Button.Left)
                return;

            var mousePosition = worldView.MapMousePosition(new Vector2f(eventArgs.X, eventArgs.Y));
            var position = worldMap.Find(mousePosition);
            if (position != null)
            {
                var location = worldMap[position];
                var newObject = (GameObject)location.Units.LastOrDefault() ?? location.Improvement;

                if (newObject != null && newObject.Owner.Active)
                {
                    newObject.Select(true);
                    activeActionResolver.Value = actionResolverFactories.Value.ObjectAction.Invoke(newObject);
                }
            }
        }
    }
}
