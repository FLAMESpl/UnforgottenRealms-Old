using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Gui.Components.ShapeBased;

namespace UnforgottenRealms.Game.Gui.Components
{
    public class CurrentRoundLabel : Label
    {
        public CurrentRoundLabel(Vector2f position, TurnCycle turnCycle)
        {
            Text = new Text
            {
                CharacterSize = 24,
                Color = Color.Black,
                DisplayedString = "1",
                Font = FontExtensions.Font
            };

            Position = position;

            turnCycle.RoundChanged += RoundChanged;
        }

        private void RoundChanged(object sender, RoundChangedEventArgs e)
        {
            Text.DisplayedString = e.Round.ToString();
        }
    }
}
