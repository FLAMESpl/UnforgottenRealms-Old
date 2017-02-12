using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Messaging;

namespace UnforgottenRealms.Common.Window
{
    public class GameWindow : RenderWindow, IEventDispatcher
    {
        public Bus Bus { get; }

        public bool Acknowledge() => true;

        public GameWindow(VideoMode video, string title, Styles styles, ContextSettings settings) 
            : base(video, title, styles, settings)
        {
            Closed += (s, e) => Close();
            Bus = new Bus();
            Bus.Subscribe(this);
        }

        public void EnsureClosed()
        {
            if (IsOpen()) Close();
        }
    }
}
