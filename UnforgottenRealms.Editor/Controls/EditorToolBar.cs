using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UnforgottenRealms.Editor.Events;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class EditorToolBar : ToolStrip
    {
        private readonly Size toolSize = new Size(23, 22);

        public event EventHandler<PaletteToolClickedEventArgs> PaletteToolClicked;

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

        private void Initialize()
        {
            GripStyle = ToolStripGripStyle.Hidden;

            AddPaletteTool(PaletteType.Terrain, "terrains");
            AddPaletteTool(PaletteType.Deposits, "deposits");
            AddPaletteTool(PaletteType.Units, "units");
            AddPaletteTool(PaletteType.Improvements, "improvements");
            AddSeparator();
            AddSeparator();
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

        private void AddSeparator() => Items.Add(new ToolStripSeparator());
    }
}
