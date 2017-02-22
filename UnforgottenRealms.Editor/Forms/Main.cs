using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Forms
{
    public partial class Main : Form, Drawable
    {
        Players playersOptionDialog = new Players();
        World worldOptionsDialog = new World();

        public Main()
        {
            InitializeComponent();
        }

        public RenderWindow InitializeSfml()
        {
            return drawingSurface.InitializeSfml();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            
        }

        private void worldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            worldOptionsDialog.ShowDialog();
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playersOptionDialog.ShowDialog();
        }

        private void toolTerrain_Click(object sender, EventArgs e)
        {
            palette.LoadContent(new PaletteContent(imagesTerrainPalette, new Size(20, 20)));
        }
    }
}
