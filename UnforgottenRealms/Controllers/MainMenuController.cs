using SFML.Graphics;
using System;
using UnforgottenRealms.Common;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Services.MainMenu;
using UnforgottenRealms.Settings;
using UnforgottenRealms.Window;

namespace UnforgottenRealms.Controllers
{
    public class MainMenuController : Controller
    {
        private const string MAIN_SCR_IMAGE = "menu.jpg";

        private PageControl pages;
        private Sprite mainScreen;
        private GameWindow window;

        public MainMenuController()
        {
            pages = new PageControl();
            mainScreen = new Sprite();
            window = GameWindowFactory.Initial();
        }

        public override ControllerResult Start(ControllerSettings settings)
        {
            var mainMenuResult = new AtomicReference<NextController>(NextController.MainMenu);
            var gameSettingsProvider = new AtomicReference<Func<GameSettings>>();

            pages.InitializeComponents(window, mainMenuResult, gameSettingsProvider);
            mainScreen.InitializeMainScreen(window, MAIN_SCR_IMAGE);

            while (window.IsOpen() && mainMenuResult.Value == NextController.MainMenu)
            {
                window.DispatchEvents();
                window.Clear();
                window.Draw(mainScreen);
                window.Draw(pages.Active);
                window.Display();
            }

            window.EnsureClosed();

            return new ControllerResult
            {
                Next = mainMenuResult.Value,
                Settings = gameSettingsProvider.Value?.Invoke()
            };
        }
    }
}
