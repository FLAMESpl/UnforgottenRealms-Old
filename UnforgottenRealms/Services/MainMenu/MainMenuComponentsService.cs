using SFML.Graphics;
using SFML.Window;
using System;
using System.Linq;
using UnforgottenRealms.Common;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Controllers;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.ShapeBased;
using UnforgottenRealms.Services.Components;
using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Services.MainMenu
{
    public static class MainMenuComponentsService
    {
        private static readonly Color backgroundColor = new Color(255, 255, 255, 127);
        private static readonly Color componentColor = new Color(255, 255, 255, 200);
        private static readonly Color highlightColor = new Color(255, 255, 127, 188);
        private static readonly Color textColor = Color.Black;
        private static readonly float navigationPanelLenght = 200;
        private static readonly float menuOptionsLeftMargin = 300;
        private static readonly Vector2f frameSizeFactor = new Vector2f(0.2f, 0.2f);

        static MainMenuComponentsService()
        {
        }

        public static void InitializeComponents(this PageControl pageControl, GameWindow window, AtomicReference<MainMenuResult> mainMenuResult, AtomicReference<Func<GameSettings>> gameSettingsProvider)
        {
            var factory = new NavigationButtonsFactory
            {
                ExpectedItems = 3,
                FontSize = 24,
                IdleColor = backgroundColor,
                HighlightColor = highlightColor,
                TextColor = textColor,
                WindowHeight = window.Size.Y,
                Width = navigationPanelLenght
            };

            var settingsFactory = new GameSettingsService
            {
                BackgroundColor = backgroundColor,
                ComponentColor = componentColor,
                HighlightColor = highlightColor,
                LeftMargin = menuOptionsLeftMargin,
                SizeFactor = frameSizeFactor,
                WindowSize = window.Size,
                TextColor = textColor,
                ComponentHeight = 40,
                ComponentMargin = 6,
                Font = FontExtensions.Font,
                FontSize = 24,
                TextPosition = new Vector2f(8, 4)
            };

            var mainView = new ComponentContainer();
            var newGameView = new ComponentContainer();
            var optionsView = new ComponentContainer();
            var settingsFrame = settingsFactory.NewFrame();

            mainView.Register(window);
            mainView.Add(factory.New(0, "NEW GAME", (s, e) => pageControl.Set(newGameView)));
            mainView.Add(factory.New(1, "OPTIONS", (s, e) => pageControl.Set(optionsView)));
            mainView.Add(factory.New(2, "EXIT", (s, e) => mainMenuResult.Value = MainMenuResult.Closed));

            newGameView.Register(window);
            newGameView.Add(factory.New(0, "START", (s, e) => mainMenuResult.Value = MainMenuResult.GameStarted));
            newGameView.Add(factory.New(2, "BACK", (s, e) => pageControl.Set(mainView)));
            newGameView.Add(settingsFrame.InitializeGameSettingsFrame(settingsFactory, gameSettingsProvider));

            optionsView.Register(window);
            optionsView.Add(factory.New(2, "BACK", (s, e) => pageControl.Set(mainView)));

            pageControl.Add(mainView);
            pageControl.Add(newGameView);
            pageControl.Add(optionsView);
            pageControl.Set(mainView);
        }

        public static void InitializeMainScreen(this Sprite sprite, GameWindow window, string image)
        {
            var path = GameEnvironment.GfxPath + image;
            var texture = new Texture(path);
            var textureSize = texture.Size;
            var scaleX = (float)window.Size.X / textureSize.X;
            var scaleY = (float)window.Size.Y / textureSize.Y;
            var scale = (Math.Abs(1f - scaleX) < (Math.Abs(1f - scaleY))) ? scaleX : scaleY;

            sprite.Scale = new Vector2f(scale, scale);
            sprite.Texture = texture;
        }

        private static Frame InitializeGameSettingsFrame(this Frame frame, GameSettingsService factory, AtomicReference<Func<GameSettings>> gameSettingsProvider)
        {
            var container = new GameSettingsComponentContainer();
            var playerNumberBox = factory.PlayerNumberTextBox();

            playerNumberBox.InputValidator = ch =>
            {
                int number = ch.AsNumber();
                return number >= 2 && number <= 4;
            };
            playerNumberBox.TextEnter += (s, e) =>
            {
                int difference = e.NewText.First().AsNumber() - e.OldText.First().AsNumber();
                container.UpdatePlayerNameTextBoxes(factory, difference);
            };
            container.Add(factory.PlayerNumberLabel());
            container.Add(playerNumberBox);
            container.AddPlayerNameTextBox(factory, 2);

            frame.Components = container;
            gameSettingsProvider.Value = () => new GameSettings { Players = container.GetPlayersMetadata() };

            return frame;
        }
    }
}
