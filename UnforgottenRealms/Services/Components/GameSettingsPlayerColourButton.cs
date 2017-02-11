using SFML.Window;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Gui.Components.ShapeBased;
using UnforgottenRealms.Common.Utils;

namespace UnforgottenRealms.Services.Components
{
    public class GameSettingsPlayerColourButton : Button
    {
        private PlayerColour colour;

        public PlayerColour Colour
        {
            get
            {
                return colour;
            }
            set
            {
                colour = value;
                SetShapeColour(value);
            }
        }


        public override void OnMouseClick(MouseButtonEventArgs args)
        {
            if (args.Button == Mouse.Button.Left)
                Colour = Colour.Next();
            else
                Colour = Colour.Prev();

            base.OnMouseClick(args);
        }

        private void SetShapeColour(PlayerColour colour)
        {
            if (Shape != null)
                Shape.FillColor = colour.ToRGB();
        }
    }
}
