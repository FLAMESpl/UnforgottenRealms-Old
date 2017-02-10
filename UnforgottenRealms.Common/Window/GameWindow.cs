using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Window
{
    public class GameWindow : RenderWindow
    {
        public GameWindow(VideoMode video, string title, Styles styles, 
            ContextSettings settings) : base(video, title, styles, settings)
        {
            Closed += (s, e) => Close();
        }
    }
}
