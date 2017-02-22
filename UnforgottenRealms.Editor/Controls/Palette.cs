using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UnforgottenRealms.Editor.Palette;
using System;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class Palette : UserControl
    {
        private PictureBox selected = null;

        public Size BrushesMargin { get; set; } = new Size(6, 6);
        public Color IdleColor { get; set; } = SystemColors.Control;
        public Color ActiveColor { get; set; } = SystemColors.ActiveCaption;

        public Palette()
        {
            InitializeComponent();
        }

        public void LoadContent(PaletteContent content)
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var image in content.Images.Images.Cast<Image>())
            {
                var picture = new PictureBox()
                {
                    BackColor = IdleColor,
                    Image = image,
                    Size = image.Size + BrushesMargin,
                    SizeMode = PictureBoxSizeMode.CenterImage
                };
                picture.Click += ChangeBrush;
                flowLayoutPanel.Controls.Add(picture);
            }
        }

        private void ChangeBrush(object sender, EventArgs e)
        {
            if (selected != null)
                selected.BackColor = IdleColor;

            var pictureBox = sender as PictureBox;
            pictureBox.BackColor = ActiveColor;
            selected = pictureBox;
        }
    }
}
