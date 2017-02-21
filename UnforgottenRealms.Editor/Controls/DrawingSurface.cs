using SFML.Graphics;
using System.ComponentModel;
using System.Windows.Forms;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class DrawingSurface : Control
    {
        public RenderWindow RenderWindow { get; protected set; }

        public DrawingSurface()
        {
            InitializeComponent();
        }

        public DrawingSurface(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public RenderWindow InitializeSfml()
        {
            RenderWindow = new RenderWindow(Handle);
            return RenderWindow;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
#if DEBUG
            if (DesignMode)
                base.OnPaint(e);
#endif
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
#if DEBUG
            if (DesignMode)
                base.OnPaintBackground(e);
#endif
        }

    }
}
