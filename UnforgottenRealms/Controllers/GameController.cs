using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Views;
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
        private View guiView;
        private WorldView worldView;

        public GameController()
        {
            InitializeResources();
            window = Window.GameWindowFactory.Initial();
            pages = new PageControl();
            worldMap = new Map(resources);
            worldView = new WorldView(window, worldMap);
        }

        public override ControllerResult Start(ControllerSettings settings)
        {
            var gameSettings = (GameSettings)settings;
            var controllerResult = NextController.Game;

            worldMap.Mock();
            RegisterHotkeys();
            while (window.IsOpen() && controllerResult == NextController.Game)
            {
                worldView.Scroll();

                window.Cycle();
                window.DispatchEvents();
                window.Clear();
                window.Draw(worldView);
                //window.Draw(pages?.Active);
                window.Display();
            }

            return new ControllerResult
            {
                Next = controllerResult,
                Settings = null
            };
        }

        private void RegisterHotkeys()
        {
            window.OnKeyPress(Keyboard.Key.Space, worldView.Center);

            window.OnKeyHold(Keyboard.Key.Left, () => worldView.Scroll(Direction.Left));
            window.OnKeyHold(Keyboard.Key.Up, () => worldView.Scroll(Direction.Up));
            window.OnKeyHold(Keyboard.Key.Right, () => worldView.Scroll(Direction.Right));
            window.OnKeyHold(Keyboard.Key.Down, () => worldView.Scroll(Direction.Down));
            window.OnKeyHold(Keyboard.Key.Add, () => worldView.ScrollSpeed += 0.001f);
            window.OnKeyHold(Keyboard.Key.Subtract, () => worldView.ScrollSpeed -= 0.001f);
        }

        private void InitializeResources()
        {
            var tilesets = new GameTilesets();
            resources = new ResourceManager();
            resources.Add(tilesets);
        }
    }
}
