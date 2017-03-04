using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Editor.Events;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class EditorToolBar : ToolStrip
    {
        private readonly int playersMinimumCount = 2;
        private readonly Size toolSize = new Size(23, 22);
        private readonly Padding playerToolPadding = new Padding(2, 0, 2, 0);

        private List<PlayerToolButton> playerTools = new List<PlayerToolButton>();
        private PlayerToolButton selectedPlayerTool = null;

        public event EventHandler<PaletteToolClickedEventArgs> PaletteToolClicked;
        public event EventHandler<PlayerSelectedEventArgs> PlayerSelected;

        private int numberOfPlayers = 0;
        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set
            {
                if (value >= playersMinimumCount && value <= playerTools.Count)
                {
                    int diff = value - numberOfPlayers;
                    if (diff > 0)
                    {
                        for (int i = numberOfPlayers; i < value; i++)
                        {
                            playerTools[i].Visible = true;
                        }
                    }
                    else if (diff < 0)
                    {
                        for (int i = value; i < numberOfPlayers; i++)
                        {
                            playerTools[i].Visible = false;
                        }
                    }
                    numberOfPlayers = value;
                    SelectPlayer(playerTools[0].Player);
                }
            }
        }

        public EditorToolBar()
        {
            InitializeComponent();
            Initialize();
        }

        public EditorToolBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }

        public void SelectPlayer(PlayerColour colour)
        {
            var newPlayerTool = playerTools.Where(x => x.Player == colour).First();
            if (selectedPlayerTool != null)
            {
                selectedPlayerTool.Select(false);
            }
            newPlayerTool.Select(true);
            selectedPlayerTool = newPlayerTool;
            PlayerSelected?.Invoke(this, new PlayerSelectedEventArgs(colour));
        }

        private void Initialize()
        {
            GripStyle = ToolStripGripStyle.Hidden;

            AddPaletteTool(PaletteType.Terrain, "terrain");
            AddPaletteTool(PaletteType.Deposits, "deposits");
            AddPaletteTool(PaletteType.Units, "units");
            AddPaletteTool(PaletteType.Improvements, "improvements");
            AddSeparator();
            AddPlayerTool(PlayerColour.Red);
            AddPlayerTool(PlayerColour.Blue);
            AddPlayerTool(PlayerColour.Yellow);
            AddPlayerTool(PlayerColour.Green);
            AddSeparator();

            NumberOfPlayers = 2;
            SelectPlayer(playerTools[0].Player);
        }

        private void AddPaletteTool(PaletteType paletteType, string imageName)
        {
            var toolStripButton = new ToolStripButton
            {
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Image = imageList.Images[imageName],
                Size = toolSize,
            };
            toolStripButton.Click += (s, e) => PaletteToolClicked?.Invoke(s, new PaletteToolClickedEventArgs(paletteType));
            Items.Add(toolStripButton);
        }

        private void AddPlayerTool(PlayerColour colour)
        {
            var toolStripButton = new PlayerToolButton();
            toolStripButton.Initialize(colour, toolSize, playerToolPadding);
            toolStripButton.Click += (s, e) => SelectPlayer(colour);
            playerTools.Add(toolStripButton);
            Items.Add(toolStripButton);
        }

        private void AddSeparator() => Items.Add(new ToolStripSeparator());
    }
}
