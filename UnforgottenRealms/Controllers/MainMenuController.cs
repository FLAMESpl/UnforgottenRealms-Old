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
    public class MainMenuController
    {
        private const string MAIN_SCR_IMAGE = "menu.jpg";

        private PageControl pages;
        private Sprite mainScreen;
        private GameWindow window;

        public GameSettings GameSettings { get; private set; }

        public MainMenuController()
        {
            pages = new PageControl();
            mainScreen = new Sprite();
            window = GameWindowFactory.Initial();
        }

        public MainMenuResult Start()
        {
            var mainMenuResult = new AtomicReference<MainMenuResult>(MainMenuResult.Continue);
            var gameSettingsProvider = new AtomicReference<Func<GameSettings>>();

            pages.InitializeComponents(window, mainMenuResult, gameSettingsProvider);
            mainScreen.InitializeMainScreen(window, MAIN_SCR_IMAGE);

            while (window.IsOpen() && mainMenuResult.Value == MainMenuResult.Continue)
            {
                window.DispatchEvents();
                window.Clear();
                window.Draw(mainScreen);
                window.Draw(pages.Active);
                window.Display();
            }

            GameSettings = gameSettingsProvider.Value?.Invoke();

            if (!window.IsOpen())
                mainMenuResult.Value = MainMenuResult.Closed;

            return mainMenuResult.Value;
        }
    }
}
