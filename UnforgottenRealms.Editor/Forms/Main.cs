﻿using SFML.Window;
using System;
using System.Windows.Forms;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Common.Geometry;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Editor.Events;
using UnforgottenRealms.Editor.Graphics;
using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Palette;
using Color = SFML.Graphics.Color;

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

        private ImageBrushPair[] terrainBrushes = null;
        private ImageBrushPair[] depositsBrushes = null;

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
            model = new HexModel(40);
            resources = new ResourceManager();
            world = new Map(model, resources);

            var tilesets = new EditorTilesets();
            CreateTerrainBrushes(tilesets.Terrain);
            CreateDepositsBrushes(tilesets.Deposits);

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
                    PalettToolLoad(terrainBrushes, Probe.Terrain);
                    break;
                case PaletteType.Deposits:
                    PalettToolLoad(depositsBrushes, Probe.Deposit);
                    break;
                case PaletteType.Units:
                    break;
                case PaletteType.Improvements:
                    break;
                default:
                    break;
            }
        }

        private void PalettToolLoad(ImageBrushPair[] images, Probe probe)
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

        private void CreateTerrainBrushes(TerrainTileset tileset)
        {
            var images = imagesTerrainPalette.Images;
            terrainBrushes = new ImageBrushPair[images.Count];

            terrainBrushes[0] = new ImageBrushPair(
                brush: new TerrainBrush(TerrainMetadata.Empty),
                image: images[0]
            );

            for (int i = 1; i < images.Count; i++)
            {
                terrainBrushes[i] = new ImageBrushPair(
                    brush: new TerrainBrush(
                        new TerrainMetadata(
                            entityId: new EntityId(
                                @class: EntityClass.Terrain,
                                value: i.ToString()
                            ),
                            textureDescriptor: tileset.Get(i-1)
                        )
                    ),
                    image: images[i]
                );
            }
        }

        public void CreateDepositsBrushes(DepositTileset tileset)
        {
            var images = imagesDepositsPalette.Images;
            depositsBrushes = new ImageBrushPair[images.Count];

            depositsBrushes[0] = new ImageBrushPair(
                brush: new DepositBrush(DepositMetadata.Empty),
                image: images[0]
            );

            for (int i = 1; i < images.Count; i++)
            {
                depositsBrushes[i] = new ImageBrushPair(
                    brush: new DepositBrush(
                        new DepositMetadata(
                            entityId: new EntityId(
                                @class: EntityClass.Deposit,
                                value: i.ToString()
                            ),
                            tile: tileset.Get(i - 1)
                        )
                    ),
                    image: images[i]
                );
            }
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
