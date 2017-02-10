using SFML.Graphics;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Services.MainMenu;
using UnforgottenRealms.Window;

namespace UnforgottenRealms.Controllers
{
    public class MainMenuController
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

        public void Start()
        {
            pages.InitializeComponents(window);
            mainScreen.InitializeMainScreen(window, MAIN_SCR_IMAGE);
            Loop();
        }

        private void Loop()
        {
            while (window.IsOpen())
            {
                window.DispatchEvents();
                window.Clear();
                window.Draw(mainScreen);
                window.Draw(pages.Active);
                window.Display();
            }
        }
    }
}
