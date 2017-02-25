using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Brush = UnforgottenRealms.Editor.Palette.Brush;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class BrushButton : PictureBox
    {
        public Color ActiveColor { get; set; }
        public Color IdleColor { get; set; }

        public Brush Brush { get; set; }

        public BrushButton()
        {
            InitializeComponent();
        }

        public BrushButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Activate() => BackColor = ActiveColor;
        public void Deactivate() => BackColor = IdleColor;
    }
}
