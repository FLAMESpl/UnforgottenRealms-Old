using SFML.Graphics;
using SFML.Window;
using System.ComponentModel;
using System.Windows.Forms;
using View = SFML.Graphics.View;

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
            RenderWindow.Resized += OnSfmlClientResize;
            return RenderWindow;
        }

        protected void OnSfmlClientResize(object sender, SizeEventArgs e)
        {
            RenderWindow.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
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
