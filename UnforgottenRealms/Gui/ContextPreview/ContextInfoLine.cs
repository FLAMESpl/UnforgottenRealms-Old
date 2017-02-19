using SFML.Graphics;

namespace UnforgottenRealms.Gui.ContextPreview
{
    public class ContextInfoLine
    {
        public Color Color { get; }
        public string Text { get; }

        public ContextInfoLine(Color color, string text)
        {
            Color = color;
            Text = text;
        }
    }
}
