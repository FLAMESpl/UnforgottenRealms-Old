using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Gui.Components.EventArguments;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.ImageBased
{
    public class Button : ImageComponentBase
    {
        public Color IdleColor { get; set; } = Color.White;
        public Color HighlightColor { get; set; }
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
                if (Image != null)
                    Image.Color = HighlightColor;
            }
        }

        public void HighlightOff(object sender, MouseMoveEventArgs e)
        {
            if (HighlightEnabled)
            {
                if (Image != null)
                    Image.Color = IdleColor;
            }
        }

        private void HighlightOffIfLostFocus(object sender, FocusChangeEventArgs e)
        {
            if (!e.Focused)
                HighlightOff(sender, null);
        }
    }
}
