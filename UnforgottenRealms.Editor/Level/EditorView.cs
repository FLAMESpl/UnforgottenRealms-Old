using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Window;

namespace UnforgottenRealms.Editor.Level
{
    public class EditorView
    {
        private GameWindow window;
        private View view;

        public float ScrollSpeed { get; set; } = 0.05f;
        public float SpeedChangeStep { get; set; } = 0.0001f;

        public EditorView(GameWindow window)
        {
            this.window = window;
            this.view = new View(window.DefaultView);
            window.Resized += OnResize;
        }

        public Vector2f MapMousePosition(Vector2f pixelPosition)
        {
            var offset = new Vector2f(view.Center.X - window.Size.X / 2, view.Center.Y - window.Size.Y / 2);
            return pixelPosition + offset;
        }

        public void IncrementScrollSpeed() => ScrollSpeed += SpeedChangeStep;
        public void DecrementScrollSpeed() => ScrollSpeed -= SpeedChangeStep;

        public void Return() => view.Center = new Vector2f();

        public void Set() => window.SetView(view);

        public void Scroll(Direction direction) => view.Move(direction.AsVector() * ScrollSpeed);

        private void OnResize(object sender, SizeEventArgs e)
        {
            var center = view.Center;
            view = new View(new FloatRect(0, 0, e.Width, e.Height));
            view.Center = center;
        }
    }
}
