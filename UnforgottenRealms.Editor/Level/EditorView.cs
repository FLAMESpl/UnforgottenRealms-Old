using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Window;

namespace UnforgottenRealms.Editor.Level
{
    public class EditorView : Drawable
    {
        private FloatRect scene;
        private Map world;
        private GameWindow window;
        private View view;

        public float ScrollSpeed { get; set; } = 0.05f;
        public float SpeedChangeStep { get; set; } = 0.0001f;

        public EditorView(GameWindow window, Map world)
        {
            this.world = world;
            this.window = window;
            this.view = new View(window.DefaultView);
            CalculateScene();
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

        public void Scroll(Direction direction)
        {
            view.Move(direction.AsVector() * ScrollSpeed);
            switch (direction)
            {
                case Direction.Up:
                    scene.Top -= ScrollSpeed;
                    break;
                case Direction.Right:
                    scene.Left += ScrollSpeed;
                    break;
                case Direction.Down:
                    scene.Top += ScrollSpeed;
                    break;
                case Direction.Left:
                    scene.Left -= ScrollSpeed;
                    break;
                default:
                    break;
            }
            world.UpdateScene(scene);
        }

        private void CalculateScene()
        {
            scene = new FloatRect(
                left: view.Center.X - window.Size.X / 2,
                top: view.Center.Y - window.Size.Y / 2,
                width: window.Size.X,
                height: window.Size.Y
            );

            world.UpdateScene(scene);
        }

        private void OnResize(object sender, SizeEventArgs e)
        {
            var center = view.Center;
            view = new View(new FloatRect(0, 0, e.Width, e.Height));
            view.Center = center;
            CalculateScene();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            window.SetView(view);
            target.Draw(world, states);
        }
    }
}
