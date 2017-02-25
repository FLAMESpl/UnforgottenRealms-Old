using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class Palette : UserControl
    {
        private List<BrushButton> brushButtons = null;
        private Probe probe = null;
        private BrushButton selected = null;

        public Size BrushesMargin { get; set; } = new Size(6, 6);

        public Palette()
        {
            InitializeComponent();
        }

        public void PaintField(Field field) => selected?.Brush.Paint(field);
        public void PickField(Field field) => ChangeBrush(brushButtons.Where(x => probe.Pick(field) == x.Brush.EntityMetadata.EntityId).Single());

        public void LoadContent(PaletteContent content)
        {
            flowLayoutPanel.Controls.Clear();
            probe = content.Probe;
            brushButtons = new List<BrushButton>();

            foreach (var image in content.Images)
            {
                var picture = new BrushButton()
                {
                    ActiveColor = SystemColors.ActiveCaption,
                    Brush = image.Brush,
                    IdleColor = SystemColors.Control,
                    Image = image.Image,
                    Size = image.Image.Size + BrushesMargin,
                    SizeMode = PictureBoxSizeMode.CenterImage
                };
                picture.Click += (s, e) => ChangeBrush(s as BrushButton);
                brushButtons.Add(picture);
                flowLayoutPanel.Controls.Add(picture);
            }
        }

        private void ChangeBrush(BrushButton brushButton)
        {
            selected?.Deactivate();
            selected = brushButton;
            selected?.Activate();
        }
    }
}
