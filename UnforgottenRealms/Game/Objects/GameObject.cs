﻿using SFML.Graphics;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Gui.ContextPreview;

namespace UnforgottenRealms.Game.Objects
{
    public abstract class GameObject : Drawable, IContextPreviewProvider
    {
        public Field Location { get; protected set; }
        public Player Owner { get; protected set; }

        public GameObject(Field location, Player owner)
        {
            Location = location;
            Owner = owner;

            Location.World.TurnCycle.RoundChanged += Refresh;
        }

        public abstract void PerformPrimaryAction(AxialCoordinates targetPosition);
        public abstract void Draw(RenderTarget target, RenderStates states);
        public abstract void Select(bool isSelected);

        protected virtual void Refresh(object sender, RoundChangedEventArgs e)
        {
        }

        protected virtual void Destroyed()
        {
            Location.World.TurnCycle.RoundChanged -= Refresh;
        }
    }
}
