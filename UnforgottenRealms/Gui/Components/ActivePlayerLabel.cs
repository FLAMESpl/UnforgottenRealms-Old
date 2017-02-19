using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Gui.Components.ShapeBased;

namespace UnforgottenRealms.Gui.Components
{
    public class ActivePlayerLabel : Label
    {
        public ActivePlayerLabel(Vector2f position, TurnCycle turnCycle)
        {
            Text = new Text
            {
                CharacterSize = 32,
                Font = FontExtensions.Font
            };

            Position = position;

            turnCycle.TurnChanged += TurnChanged;
        }

        private void TurnChanged(object sender, ValueChangedEventArgs<Player> e)
        {
            Text.DisplayedString = e.New.Name;
            Text.Color = e.New.Colour.ToRGB();
        }
    }
}
