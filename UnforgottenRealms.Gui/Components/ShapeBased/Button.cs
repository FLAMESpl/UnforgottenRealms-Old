using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Gui.Components.EventArguments;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.ShapeBased
{
    public class Button : ShapeComponentBase
    {
        public Color IdleBackgroundColor { get; set; }
        public Color IdleTextColor { get; set; }
        public Color HighlightBackgroundColor { get; set; }
        public Color HighlightTextColor { get; set; }
        public bool HighlightEnabled { get; set; }
        public bool Highlighted { get; protected set; }

        public Button()
        {
            MouseEnter += HighlightOn;
            MouseLeave += HighlightOff;
            FocusChange += HighlightOffIfLostFocus;
        }

        public void HighlightOn(object sender, MouseMoveEventArgs e)
        {
            if (HighlightEnabled)
            {
                if (Shape != null)
                    Shape.FillColor = HighlightBackgroundColor;
                if (Text != null)
                    Text.Color = HighlightTextColor;
            }
        }

        public void HighlightOff(object sender, MouseMoveEventArgs e)
        {
            if (HighlightEnabled)
            {
                if (Shape != null)
                    Shape.FillColor = IdleBackgroundColor;
                if (Text != null)
                    Text.Color = IdleTextColor;
            }
        }

        private void HighlightOffIfLostFocus(object sender, FocusChangeEventArgs e)
        {
            if (!e.Focused)
                HighlightOff(sender, null);
        }
    }
}
