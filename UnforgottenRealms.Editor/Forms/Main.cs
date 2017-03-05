using SFML.Window;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Geometry;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Editor.Events;
using UnforgottenRealms.Editor.Graphics;
using UnforgottenRealms.Editor.Helpers;
using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Forms
{
    public partial class Main : Form
    {
        private NewLevel newLevelDialog = new NewLevel();
        private PlayersOptions playersOptionsDialog = new PlayersOptions();
        private WorldOptions worldOptionsDialog = new WorldOptions();

        private EditorView editorView;
        private HexModel model = null;
        private ResourceManager resources;
        private GameWindow window;
        private Map world;

        private List<ImageBrushPair> depositsBrushes;
        private List<ImageBrushPair> improvementBrushes;
        private List<ImageBrushPair> terrainBrushes;
        private List<ImageBrushPair> unitsBrushes;

        public Main()
        {
            InitializeComponent();

            var allowedNumbersOfPlayers = new int[] { 2, 3, 4 };

            newLevelDialog.SetAllowedNumbersOfPlayers(allowedNumbersOfPlayers);
            playersOptionsDialog.SetAllowedNumbersOfPlayers(allowedNumbersOfPlayers);

            newLevelDialog.NewLevelCreated += NewLevelCreated;
            playersOptionsDialog.PlayerOptionsChanged += PlayerOptionsChanged;

            toolBar.PaletteToolClicked += PaletteToolClicked;
        }

        public void Process()
        {
            window.DispatchEvents();
            window.Cycle();

            DrawOnSurface();

            window.Clear();
            window.Draw(editorView);
            window.Display();
        }

        public void InitializeSfml()
        {
            var tilesets = new EditorTilesets();

            model = new HexModel(40);
            resources = new ResourceManager();
            resources.Add(tilesets);

            CreateBrushes(tilesets);
            toolBar.SelectPlayer(PlayerColour.Red);

            world = new Map(model, resources);
            world.Create(new Vector2i(10, 10));

            window = drawingSurface.InitializeSfml();
            editorView = new EditorView(window, world);

            window.OnKeyPress(Keyboard.Key.Space, () => editorView.Return());
            window.OnKeyHold(Keyboard.Key.Left, () => editorView.Scroll(Direction.Left));
            window.OnKeyHold(Keyboard.Key.Right, () => editorView.Scroll(Direction.Right));
            window.OnKeyHold(Keyboard.Key.Up, () => editorView.Scroll(Direction.Up));
            window.OnKeyHold(Keyboard.Key.Down, () => editorView.Scroll(Direction.Down));
            window.OnKeyHold(Keyboard.Key.Add, editorView.IncrementScrollSpeed);
            window.OnKeyHold(Keyboard.Key.Subtract, editorView.DecrementScrollSpeed);
        }

        private void PaletteToolClicked(object sender, PaletteToolClickedEventArgs e)
        {
            switch (e.PaletteType)
            {
                case PaletteType.Terrain:
                    PaletteToolLoad(terrainBrushes, Probe.Terrain);
                    break;
                case PaletteType.Deposits:
                    PaletteToolLoad(depositsBrushes, Probe.Deposit);
                    break;
                case PaletteType.Units:
                    PaletteToolLoad(unitsBrushes, Probe.Unit);
                    break;
                case PaletteType.Improvements:
                    PaletteToolLoad(improvementBrushes, Probe.Improvement);
                    break;
                default:
                    break;
            }
        }

        private void PaletteToolLoad(IEnumerable<ImageBrushPair> images, Probe probe)
        {
            palette.LoadContent(new PaletteContent(images, probe));
        }

        private void worldToolStripMenuItem_Click(object sender, EventArgs e) => worldOptionsDialog.ShowDialog();
        private void playersToolStripMenuItem_Click(object sender, EventArgs e) => playersOptionsDialog.ShowDialog();

        private void DrawOnSurface()
        {
            var mousePosition = Mouse.GetPosition(window);
            var mouseLeftButtonPressed = Mouse.IsButtonPressed(Mouse.Button.Left);
            var mouseRightButtonPressed = Mouse.IsButtonPressed(Mouse.Button.Right);

            if (!mouseLeftButtonPressed && !mouseRightButtonPressed || !window.Contains(mousePosition))
                return;

            var position = model.FindHex(editorView.MapMousePosition(new Vector2f(mousePosition.X, mousePosition.Y)));
            if (!world.Contains(position))
                return;

            if (mouseLeftButtonPressed)
                palette.PaintField(world[position]);
            else if (mouseRightButtonPressed)
                palette.PickField(world[position]);
        }

        private void CreateBrushes(EditorTilesets tilesets)
        {
            ImageList.ImageCollection images;

            images = terrainPaletteImages.Images;
            terrainBrushes = new List<ImageBrushPair>();

            terrainBrushes.AddTerrainBrush(images["none"], TerrainMetadata.Empty);
            terrainBrushes.AddTerrainBrush(images["grass"], TerrainDefinitions.Grass, tilesets.Terrain.Grass);
            terrainBrushes.AddTerrainBrush(images["desert"], TerrainDefinitions.Desert, tilesets.Terrain.Desert);
            terrainBrushes.AddTerrainBrush(images["water"], TerrainDefinitions.Water, tilesets.Terrain.Water);
            terrainBrushes.AddTerrainBrush(images["forest"], TerrainDefinitions.Forest, tilesets.Terrain.Forest);
            terrainBrushes.AddTerrainBrush(images["hill"], TerrainDefinitions.Hill, tilesets.Terrain.Hill);
            terrainBrushes.AddTerrainBrush(images["mountain"], TerrainDefinitions.Mountain, tilesets.Terrain.Mountain);

            images = depositsPaletteImages.Images;
            depositsBrushes = new List<ImageBrushPair>();

            depositsBrushes.AddDepositBrush(images["none"], DepositMetadata.Empty);
            depositsBrushes.AddDepositBrush(images["iron"], DepositsDefinitions.Iron, tilesets.Deposits.Iron);
            depositsBrushes.AddDepositBrush(images["gems"], DepositsDefinitions.Gems, tilesets.Deposits.Gems);
            depositsBrushes.AddDepositBrush(images["pearls"], DepositsDefinitions.Pearls, tilesets.Deposits.Pearls);

            images = unitsPalleteImages.Images;
            unitsBrushes = new List<ImageBrushPair>();

            unitsBrushes.AddUnitBrush(images["none"], UnitMetadata.Empty);
            unitsBrushes.AddUnitBrush(toolBar, images["worker"], UnitsDefinitions.Worker, tilesets.Units.Worker);
            unitsBrushes.AddUnitBrush(toolBar, images["archer"], UnitsDefinitions.Archer, tilesets.Units.Archer);
            unitsBrushes.AddUnitBrush(toolBar, images["swordsman"], UnitsDefinitions.Swordsman, tilesets.Units.Swordsman);
            unitsBrushes.AddUnitBrush(toolBar, images["horseman"], UnitsDefinitions.Horseman, tilesets.Units.Horseman);
            unitsBrushes.AddUnitBrush(toolBar, images["boat"], UnitsDefinitions.Boat, tilesets.Units.Boat);
            unitsBrushes.AddUnitBrush(toolBar, images["dragon"], UnitsDefinitions.Dragon, tilesets.Units.Dragon);

            images = improvementsPalleteImages.Images;
            improvementBrushes = new List<ImageBrushPair>();

            improvementBrushes.AddImprovementBrush(images["none"], ImprovementMetadata.Empty);
            improvementBrushes.AddImprovementBrush(toolBar, images["farm"], ImprovementDefinitions.Farm, tilesets.Improvements.Farm);
            improvementBrushes.AddImprovementBrush(toolBar, images["lumberjacks"], ImprovementDefinitions.LumberjacksHut, tilesets.Improvements.LumberjacksHut);
            improvementBrushes.AddImprovementBrush(toolBar, images["mine"], ImprovementDefinitions.Mine, tilesets.Improvements.IronMine);
            improvementBrushes.AddImprovementBrush(toolBar, images["barracks"], ImprovementDefinitions.Barracks, tilesets.Improvements.Barracks);
            improvementBrushes.AddImprovementBrush(toolBar, images["stable"], ImprovementDefinitions.Stable, tilesets.Improvements.Stable);
            improvementBrushes.AddImprovementBrush(toolBar, images["shipyard"], ImprovementDefinitions.Shipyard, tilesets.Improvements.Shipyard);
            improvementBrushes.AddImprovementBrush(toolBar, images["dragonlair"], ImprovementDefinitions.DragonLair, tilesets.Improvements.DragonLair);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newLevelDialog.ShowDialog();
        }

        private void NewLevelCreated(object sender, NewLevelEventArgs e)
        {
            palette.Unload();
            world.Create(e.Size);
            toolBar.NumberOfPlayers = e.NumberOfPlayers;
        }

        private void PlayerOptionsChanged(object sender, PlayersOptionsChangedEventArgs e)
        {
            toolBar.NumberOfPlayers = e.NumberOfPlayers;
        }
    }
}
