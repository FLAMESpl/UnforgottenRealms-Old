﻿using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
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
        private WorldView worldView;
        private List<Player> players = new List<Player>();
        private TurnCycle turnCycle;

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

            InitializeGameState(gameSettings);
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
            window.OnKeyHold(Keyboard.Key.Left, () => worldView.Scroll(Direction.Left));
            window.OnKeyHold(Keyboard.Key.Up, () => worldView.Scroll(Direction.Up));
            window.OnKeyHold(Keyboard.Key.Right, () => worldView.Scroll(Direction.Right));
            window.OnKeyHold(Keyboard.Key.Down, () => worldView.Scroll(Direction.Down));
            window.OnKeyHold(Keyboard.Key.Add, () => worldView.ScrollSpeed += 0.001f);
            window.OnKeyHold(Keyboard.Key.Subtract, () => worldView.ScrollSpeed -= 0.001f);

            window.OnKeyPress(Keyboard.Key.Space, worldView.Center);
            window.OnKeyPress(Keyboard.Key.F9, turnCycle.Next);
        }

        private void InitializeGameState(GameSettings settings)
        {
            foreach (var playerMetadata in settings.Players)
                players.Add(playerMetadata.CreatePlayer());

            turnCycle = new TurnCycle(players);
            turnCycle.First();
            worldMap.Mock(players);
        }

        private void InitializeResources()
        {
            var tilesets = new GameTilesets();
            resources = new ResourceManager();
            resources.Add(tilesets);
        }
    }
}
