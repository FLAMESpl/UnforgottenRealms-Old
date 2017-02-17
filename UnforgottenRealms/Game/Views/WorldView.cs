using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Views
{
    public class WorldView : Drawable
    {
        private View view;
        private GameWindow window;
        private Map map;

        public float ScrollSpeed { get; set; } = 0.25f;
        public float ScrollSenseDistance { get; set; } = 5;

        public WorldView(GameWindow window, Map map)
        {
            this.window = window;
            this.map = map;
            this.view = window.DefaultView;
        }
        
        public void Center()
        {
            var size = map.PixelSize;
            var middle = size / 2;
            view.Center = middle;
        }

        public void Scroll()
        {
            bool moved = false;
            var offset = new Vector2f();
            var mousePosition = Mouse.GetPosition(window);
            if (mousePosition.X < ScrollSenseDistance)
            {
                offset.X = -ScrollSpeed;
                moved = true;
            }
            else if (window.Size.X - mousePosition.X < ScrollSenseDistance)
            {
                offset.X = ScrollSpeed;
                moved = true;
            }
            if (mousePosition.Y < ScrollSenseDistance)
            {
                offset.Y = -ScrollSpeed;
                moved = true;
            }
            else if (window.Size.Y - mousePosition.Y < ScrollSenseDistance)
            {
                offset.Y = ScrollSpeed;
                moved = true;
            }

            if (moved)
                view.Move(offset);
        }

        public void Scroll(Direction direction)
        {
            view.Move(direction.AsVector() * ScrollSpeed);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.SetView(view);
            target.Draw(map, states);
        }
    }
}
