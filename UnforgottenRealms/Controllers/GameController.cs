using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Controllers
{
    public class GameController : Controller
    {
        private GameWindow window;
        private Map worldMap;
        private PageControl pages;
        private ResourceManager resources;
        private View worldView;
        private View guiView;

        public GameController()
        {
            InitializeResources();
            window = Window.GameWindowFactory.Initial();
            pages = new PageControl();
            worldMap = new Map(resources);
            worldView = window.DefaultView;
        }

        public override ControllerResult Start(ControllerSettings settings)
        {
            var gameSettings = (GameSettings)settings;
            var controllerResult = NextController.Game;
            worldMap.MockMap();

            while (window.IsOpen() && controllerResult == NextController.Game)
            {
                Scroll();

                window.DispatchEvents();
                window.Clear();
                window.SetView(worldView);
                window.Draw(worldMap);
                window.SetView(guiView);
                //window.Draw(pages?.Active);
                window.Display();
            }

            return new ControllerResult
            {
                Next = controllerResult,
                Settings = null
            };
        }

        private void InitializeResources()
        {
            var tilesets = new GameTilesets();
            resources = new ResourceManager();
            resources.Add(tilesets);
        }

        private void CenterWorld()
        {
            var size = worldMap.PixelSize;
            var middle = size / 2;
            worldView.Center = middle;
        }

        private void Scroll()
        {
            bool moved = false;
            var offset = new Vector2f();
            var mousePosition = Mouse.GetPosition(window);
            var scrollSpeed = 1;
            var scrollDistance = 5;
            if (mousePosition.X < scrollDistance)
            {
                offset.X = -scrollSpeed;
                moved = true;
            }
            else if (window.Size.X - mousePosition.X < scrollDistance)
            {
                offset.X = scrollSpeed;
                moved = true;
            }
            if (mousePosition.Y < scrollDistance)
            {
                offset.Y = -scrollSpeed;
                moved = true;
            }
            else if (window.Size.Y - mousePosition.Y < scrollDistance)
            {
                offset.Y = scrollSpeed;
                moved = true;
            }

            if (moved)
                worldView.Move(offset);
        }
    }
}
