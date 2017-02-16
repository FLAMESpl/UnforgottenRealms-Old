using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public GameController()
        {
            InitializeResources();
            window = Window.GameWindowFactory.Initial();
            pages = new PageControl();
            worldMap = new Map(resources);
        }

        public override ControllerResult Start(ControllerSettings settings)
        {
            var gameSettings = (GameSettings)settings;
            var controllerResult = NextController.Game;
            worldMap.MockMap();

            while (window.IsOpen() && controllerResult == NextController.Game)
            {
                window.DispatchEvents();
                window.Clear();
                window.Draw(worldMap);
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
    }
}
